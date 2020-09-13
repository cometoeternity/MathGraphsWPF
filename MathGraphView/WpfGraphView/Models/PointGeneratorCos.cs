using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGraphView.Models
{
   public class PointGeneratorCos:IDataErrorInfo
   {
        public float CosLimitStart { get; set; } = 0f;
        public float CosLimitFinish { get; set; } = 20f;
        public float CosAmplit { get; set; } = 1f;
        public float CosSjatie { get; set; } = 1f;
        public float CosXSdvig { get; set; } = 0f;
        public float CosYSdvig { get; set; } = 0f;
        public List<Point> Points { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
        {
            string error = String.Empty;
            switch (columnName)
            {
                case "CosLimitStart":

                    if (string.IsNullOrWhiteSpace(this.CosLimitStart.ToString()))
                    {
                        MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;

                case "CosLimitFinish":
                    if (string.IsNullOrWhiteSpace(CosLimitFinish.ToString()))
                    {
                        MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;

                case "CosAmplit":
                    if (string.IsNullOrWhiteSpace(this.CosAmplit.ToString()) || this.CosAmplit == 0)
                    {
                        MessageBox.Show("Поле не может быть пустым или равно 0!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;

                case "CosSjatie":
                    if (string.IsNullOrWhiteSpace(this.CosSjatie.ToString()) || this.CosSjatie == 0)
                    {
                        MessageBox.Show("Поле не может быть пустым или равно 0!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;

                case "CosXSdvig":
                    if (string.IsNullOrWhiteSpace(CosXSdvig.ToString()))
                    {
                        MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;

                case "CosYSdvig":
                    if (string.IsNullOrWhiteSpace(CosYSdvig.ToString()))
                    {
                        MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                default:
                    throw new ArgumentException("Неизвестная ошибка ввода!", columnName);
            }
            return error;
            }
        }

        public PointGeneratorCos()
        {
            Points = new List<Point>();
        }
        public PointGeneratorCos(float cosLimitStart, float cosLimitFinish, float cosAmplit, float cosSjatie, float cosXSdvig, float cosYSdvig)
        {
            CosLimitStart = cosLimitStart;
            CosLimitFinish = cosLimitFinish;
            CosAmplit = cosAmplit;
            CosSjatie = cosSjatie;
            CosXSdvig = cosXSdvig;
            CosYSdvig = cosYSdvig;

        }
        public List<Point> PointGenerator ()
        {
            Points = new List<Point>();
            for(float x= CosLimitStart; x< CosLimitFinish; x+=0.5f)
            {
                Points.Add(new Point(x, Calculate(x, CosAmplit, CosSjatie, CosXSdvig, CosYSdvig)));
            }
            return Points;
        }

        private float Calculate(float x,float cosAmplit, float cosSjatie, float cosXSdvig, float cosYSdvig)
        {
            return (float)(cosAmplit*Math.Cos(x* cosSjatie + cosXSdvig) + cosYSdvig);  
        }
    }
}

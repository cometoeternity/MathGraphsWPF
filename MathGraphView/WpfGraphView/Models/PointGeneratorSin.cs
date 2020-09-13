using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGraphView.Models
{
    public class PointGeneratorSin:IDataErrorInfo
    {
        public float SinLimitStart { get; set; } = 0f;
        public float SinLimitFinish { get; set; } = 20f;
        public float SinAmplit { get; set; } = 1f;
        public float SinSjatie { get; set; } = 1f;
        public float SinXSdvig { get; set; } = 0f;
        public float SinYSdvig { get; set; } = 0f;
        public List<Point> Points { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "SinLimitStart":
                        if (string.IsNullOrWhiteSpace(this.SinLimitStart.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "SinLimitFinish":
                        if (string.IsNullOrWhiteSpace(SinLimitFinish.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "SinAmplit":
                        if (string.IsNullOrWhiteSpace(this.SinAmplit.ToString()) || this.SinAmplit == 0)
                        {
                            MessageBox.Show("Поле не может быть пустым или равно 0!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "SinSjatie":
                        if (string.IsNullOrWhiteSpace(this.SinSjatie.ToString()) || this.SinSjatie == 0)
                        {
                            MessageBox.Show("Поле не может быть пустым или равно 0!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "SinXSdvig":
                        if (string.IsNullOrWhiteSpace(SinXSdvig.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "SinYSdvig":
                        if (string.IsNullOrWhiteSpace(SinYSdvig.ToString()))
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
        public PointGeneratorSin(float sinLimitStart, float sinLimitFinish, float sinAmplit, float sinSjatie, float sinXSdvig, float sinYSdvig)
        {
            SinLimitStart= sinLimitStart;
            SinLimitFinish = sinLimitFinish;
            SinAmplit = sinAmplit;
            SinSjatie = sinAmplit;
            SinXSdvig = sinXSdvig;
            SinYSdvig = sinYSdvig;
        }

        public PointGeneratorSin()
        {
            Points = new List<Point>();
        }
        public List<Point> PointGenerator()
        {
            Points = new List<Point>();
                for (float x = SinLimitStart; x < SinLimitFinish; x += 0.05f)
                {
                    Points.Add(new Point(x, Calculate(x, SinAmplit, SinSjatie, SinXSdvig, SinYSdvig)));

                }
               return Points;
        }

        private float Calculate(double x, double sinAmplit, double sinSjatie, double sinXSdvig, double sinYSdvig)
        {
            return (float)(sinAmplit * Math.Sin(x * sinSjatie + sinXSdvig) + sinYSdvig);
        }
    }
}


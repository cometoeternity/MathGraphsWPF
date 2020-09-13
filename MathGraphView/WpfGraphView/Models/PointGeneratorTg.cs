using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGraphView.Models
{
    public class PointGeneratorTg : IDataErrorInfo
    {
        public float TgLimitStart { get; set; } = 0f;
        public float TgLimitFinish { get; set; } = 20f;
        public float TgAmplit { get; set; } = 1f;
        public float TgSjatie { get; set; } = 1f;
        public float TgXSdvig { get; set; } = 0f;
        public float TgYSdvig { get; set; } = 0f;
        public List<Point> Points { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "TgLimitStart":
                        
                        if (string.IsNullOrWhiteSpace(this.TgLimitStart.ToString()))
                        { 
                            MessageBox.Show("Поле не может быть пустым!","Ошибка Ввода данных!",MessageBoxButton.OK,MessageBoxImage.Error); 
                        }
                        break;

                    case "TgLimitFinish":
                        if(string.IsNullOrWhiteSpace(TgLimitFinish.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "TgAmplit":
                        if(string.IsNullOrWhiteSpace(this.TgAmplit.ToString()) || this.TgAmplit == 0)
                        {
                            MessageBox.Show("Поле не может быть пустым или равно 0!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "TgSjatie":
                        if (string.IsNullOrWhiteSpace(this.TgSjatie.ToString()) || this.TgSjatie == 0)
                        {
                            MessageBox.Show("Поле не может быть пустым или равно 0!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "TgXSdvig":
                        if(string.IsNullOrWhiteSpace(TgXSdvig.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "TgYSdvig":
                        if(string.IsNullOrWhiteSpace(TgYSdvig.ToString()))
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
        public PointGeneratorTg()
        {
            Points = new List<Point>();
        }

        public PointGeneratorTg(float tgLimitStart, float tgLimitFinish, float tgAmplit, float tgSjatie, float tgXSdvig, float tgYSdvig)
        {
            Points = new List<Point>();
            TgLimitStart = tgLimitStart;
            TgLimitFinish = tgLimitFinish;
            TgAmplit = tgAmplit;
            TgSjatie = tgSjatie;
            TgXSdvig = tgXSdvig;
            TgYSdvig = tgYSdvig;
        }
        public List<Point> PointGenerator()
        {
            Points = new List<Point>();
            for (float x = TgLimitStart; x < TgLimitFinish; x += 0.05f)
            {
                Points.Add(new Point(x, Calculate(x, TgAmplit, TgSjatie, TgXSdvig, TgYSdvig)));
            }
            return Points;
        }

        private float Calculate(float x, float TgAmplit, float TgSjatie, float TgXSdvig, float TgYSdvig)
        {
            return (float)(TgAmplit * Math.Tan(x* TgSjatie + TgXSdvig) + TgYSdvig);
        }
    }
}


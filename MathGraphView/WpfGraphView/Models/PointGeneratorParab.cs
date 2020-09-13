using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGraphView.Models
{
   public class PointGeneratorParab : IDataErrorInfo
   {
        public float ParabLimitStart { get; set; } = 0f;
        public float ParabLimitFinish { get; set; } = 100f;
        public float ParabPow { get; set; } = 2f;
        public float ParabSjatie { get; set; } = 1f;
        public float ParabXSdvig { get; set; } = 0f;
        public float ParabYSdvig { get; set; } = 0f;
        public List<Point> Points { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "ParabLimitStart":

                        if (string.IsNullOrWhiteSpace(this.ParabLimitStart.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ParabLimitFinish":
                        if (string.IsNullOrWhiteSpace(ParabLimitFinish.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ParabPow":
                        if (string.IsNullOrWhiteSpace(this.ParabPow.ToString()) || this.ParabPow == 0)
                        {
                            MessageBox.Show("Поле не может быть пустым или равно 0!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ParaSjatie":
                        if (string.IsNullOrWhiteSpace(this.ParabSjatie.ToString()) || this.ParabSjatie == 0)
                        {
                            MessageBox.Show("Поле не может быть пустым или равно 0!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ParaXSdvig":
                        if (string.IsNullOrWhiteSpace(ParabXSdvig.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ParabYSdvig":
                        if (string.IsNullOrWhiteSpace(ParabYSdvig.ToString()))
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

        public PointGeneratorParab()
        {
            Points = new List<Point>();
        }
        public PointGeneratorParab(float parabLimitStart, float parabLimitFinish, float parabPow, float parabSjatie, float parabXSdvig, float parabYSdvig)
        {
            Points = new List<Point>();
            ParabLimitStart = parabLimitStart;
            ParabLimitFinish = parabLimitFinish;
            ParabPow = parabPow;
            ParabSjatie = parabSjatie;
            ParabXSdvig = parabXSdvig;
            ParabYSdvig = parabYSdvig;
        }
        public List<Point> PointGenerator()
        {
            Points = new List<Point>();
            for (float x = ParabLimitStart; x < ParabLimitFinish; x += 0.05f)
            {
                Points.Add(new Point(x, Calculate(x, ParabSjatie, ParabXSdvig, ParabYSdvig, ParabPow)));
            }
            return Points;
        }

        private float Calculate(float x, float parabSjatie, float parabXSdvig, float parabYSdvig, float parabPow)
        {
            return (float)(parabSjatie * Math.Pow(x + parabXSdvig, parabPow)+ parabYSdvig);    
        }
    }
}


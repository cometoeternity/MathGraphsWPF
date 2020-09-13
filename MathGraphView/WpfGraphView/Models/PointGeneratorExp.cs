using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGraphView.Models
{
    public class PointGeneratorExp : IDataErrorInfo
    {
        public float ExpLimitStart { get; set; } = 0f;
        public float ExpLimitFinish { get; set; } = 20f;
        public float ExpAmplit { get; set; } = 1f;
        public float ExpSjatie { get; set; } = 1f;
        public float ExpXSdvig { get; set; } = 0f;
        public float ExpYSdvig { get; set; } = 0f;
        public List<Point> Points { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]

        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "ExpLimitStart":

                        if (string.IsNullOrWhiteSpace(this.ExpLimitStart.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ExpLimitFinish":
                        if (string.IsNullOrWhiteSpace(ExpLimitFinish.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ExpAmplit":
                        if (string.IsNullOrWhiteSpace(this.ExpAmplit.ToString()) || this.ExpAmplit == 0)
                        {
                            MessageBox.Show("Поле не может быть пустым или равно 0!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ExpSjatie":
                        if (string.IsNullOrWhiteSpace(this.ExpSjatie.ToString()) || this.ExpSjatie == 0)
                        {
                            MessageBox.Show("Поле не может быть пустым или равно 0!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ExpXSdvig":
                        if (string.IsNullOrWhiteSpace(ExpXSdvig.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ExpYSdvig":
                        if (string.IsNullOrWhiteSpace(ExpYSdvig.ToString()))
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

        public PointGeneratorExp()
        {
            Points = new List<Point>();
        }
        public PointGeneratorExp(float expLimitStart, float expLimitFinish, float expAmplit, float expSjatie, float expXSdvig, float expYSdvig)
        {
            Points = new List<Point>();
            ExpLimitStart = expLimitStart;
            ExpLimitFinish = expLimitFinish;
            ExpAmplit = expAmplit;
            ExpSjatie = expSjatie;
            ExpXSdvig = expXSdvig;
            ExpYSdvig = expYSdvig;
        }
        public List<Point> PointGenerator()
        {
            Points = new List<Point>();
            for (float x = ExpLimitStart; x < ExpLimitFinish; x += 0.5f)
            {
                Points.Add(new Point(x, Calculate(x, ExpAmplit, ExpSjatie, ExpXSdvig, ExpYSdvig)));
            }
            return Points;
        }

        private float Calculate(float x, float expAmplit, float expSjatie, float expXSdvig, float expYSdvig)
        {
            return (float)(expAmplit * Math.Exp(x * expSjatie + expXSdvig) + expYSdvig);
        }
    }
}


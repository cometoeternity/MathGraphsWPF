using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGraphView.Models
{
    public class PointGeneratorLog : IDataErrorInfo
    {
        public float LogLimitStart { get; set; } = 0f;
        public float LogLimitFinish { get; set; } = 20f;
        public float LogAmplit { get; set; } = 1f;
        public float LogSjatie { get; set; } = 1f;
        public float LogXSdvig { get; set; } = 0f;
        public float LogYSdvig { get; set; } = 0f;
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

                        if (string.IsNullOrWhiteSpace(this.LogLimitStart.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ExpLimitFinish":
                        if (string.IsNullOrWhiteSpace(LogLimitFinish.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ExpAmplit":
                        if (string.IsNullOrWhiteSpace(this.LogAmplit.ToString()) || this.LogAmplit == 0)
                        {
                            MessageBox.Show("Поле не может быть пустым или равно 0!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ExpSjatie":
                        if (string.IsNullOrWhiteSpace(this.LogSjatie.ToString()) || this.LogSjatie == 0)
                        {
                            MessageBox.Show("Поле не может быть пустым или равно 0!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ExpXSdvig":
                        if (string.IsNullOrWhiteSpace(LogXSdvig.ToString()))
                        {
                            MessageBox.Show("Поле не может быть пустым!", "Ошибка Ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "ExpYSdvig":
                        if (string.IsNullOrWhiteSpace(LogYSdvig.ToString()))
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
        public PointGeneratorLog(float logLimitStart, float logLimitFinish, float logAmplit, float logSjatie, float expXSdvig, float expYSdvig)
        {
            Points = new List<Point>();
            LogLimitStart = logLimitStart;
            LogLimitFinish = logLimitFinish;
            LogAmplit = logAmplit;
            LogSjatie = logSjatie;
            LogXSdvig = expXSdvig;
            LogYSdvig = expYSdvig;
        }


        public PointGeneratorLog()
        {
            Points = new List<Point>();
        }
        public List<Point> PointGenerator()
        {
            Points = new List<Point>();
            for (float x = LogLimitStart; x < LogLimitFinish; x += 0.5f)
            {
                Points.Add(new Point(x, Calculate(x, LogAmplit, LogSjatie, LogXSdvig, LogYSdvig)));
            }
            return Points;
        }

        private float Calculate(float x, float logAmplit, float logSjatie, float logXSdvig, float logYSdvig)
        {
            return (float)(logAmplit * Math.Log10(x * logSjatie + logXSdvig) + logYSdvig);
        }
    }
}


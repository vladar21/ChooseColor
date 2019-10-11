using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ChooseColor.Models;
using ChooseColor.Commands;

namespace ChooseColor.ViewModels
{

    public class MainWindowViewModel : BaseViewModel
    {
        // определяем свойство, на которое будет биндится контролл с числовым значением параметра alpha
        private byte colorAlphaComponent = byte.MaxValue;
        public byte ColorAlphaComponent
        {
            get => colorAlphaComponent;
            //set => SetProperty(ref colorAlphaComponent, value);
            set
            {
                SetProperty(ref colorAlphaComponent, value);
                UpdateSelectedColor();
            }
        }
        // определяем свойство, на которое будет биндится контролл с числовым значением параметра red
        private byte colorRedComponent;
        public byte ColorRedComponent
        {
            get => colorRedComponent;
            //set => SetProperty(ref colorRedComponent, value);
            set
            {
                SetProperty(ref colorRedComponent, value);
                UpdateSelectedColor();
            }
        }
        // определяем свойство, на которое будет биндится контролл с числовым значением параметра green
        private byte colorGreenComponent;
        public byte ColorGreenComponent
        {
            get => colorGreenComponent;
            //set => SetProperty(ref colorGreenComponent, value);
            set
            {
                SetProperty(ref colorGreenComponent, value);
                UpdateSelectedColor();
            }
        }
        // определяем свойство, на которое будет биндится контролл с числовым значением параметра blue
        private byte colorBlueComponent;
        public byte ColorBlueComponent
        {
            get => colorBlueComponent;
            //set => SetProperty(ref colorBlueComponent, value);
            set
            {
                SetProperty(ref colorBlueComponent, value);
                UpdateSelectedColor();
            }
        }
        // 
        private string selectedColor;
        public string SelectedColor
        {
            get => selectedColor;
            set => SetProperty(ref selectedColor, value);
        }
        // создаем цвет
        private Color CreateColor()
        {
            return new Color(ColorAlphaComponent, ColorRedComponent, ColorGreenComponent, ColorBlueComponent);
        }
        // обновляем свойство с выбранным цветом на текущий цвет
        private void UpdateSelectedColor()
        {
            SelectedColor = CreateColor().Name;
        }

        // свойство для хранения списка выбранных цветов
        private readonly ObservableCollection<string> colors = new ObservableCollection<string>();
        public ICollection<string> Colors => colors;
        private string _colorAdd;
        public string ColorAdd
        {
            get => _colorAdd;
            set
            {
                SetProperty(ref _colorAdd, value);
            }
        }
        private string _colorDel;
        public string ColorDel
        {
            get => _colorDel;
            set
            {
                SetProperty(ref _colorDel, value);
            }
        }
        // команда на добаление текущего цвета в листбокс
        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                { _addCommand = new RelayCommand<object>(this.AddCommand_Execute); }
                return _addCommand;
            }
        }
        private void AddCommand_Execute(object parameter)
        {
            ColorAdd = parameter.ToString();
            Colors.Add(ColorAdd);
        }

        // команда на удаление цвета из листбокса
        private ICommand _delCommand;
        public ICommand DelCommand
        {
            get
            {
                if (_delCommand == null)
                { _delCommand = new RelayCommand<object>(this.DelCommand_Execute); }
                return _delCommand;
            }
        }
        private void DelCommand_Execute(object parameter)
        {
            ColorDel = parameter.ToString();
            Colors.Remove(ColorDel);
        }

    }

}
using System;
using System.Collections.Generic;
using System.Windows;

namespace CSharp
{
    public enum EnumForComboBox { Value1, Value2, Value3 };

    public sealed class MainViewModel : ViewModel
    {
        private MyEnum testEnumToImage;
        private bool boolToImageTrue;
        private bool boolToImageFalse;
        private List<SimpleDataGridExample> simpleDataGridList;
        private List<ClassWithFuncExample> classWithFuncList;
        private ClassWithFuncExample selectedClassWithFunc;
        private EnumForComboBox selectedEnumValue;

        public MainViewModel()
        {
            RunCommand = new DelegateCommand<string>(RunExecute);

            // For testing images (converters)
            TestEnumToImage = MyEnum.test1;
            BoolToImageTrue = true;
            BoolToImageFalse = false;

            // For testing DataGrids
            SimpleDataGridList = new List<SimpleDataGridExample>
            {
                new SimpleDataGridExample(1.1, 78, false, "test string"),
                new SimpleDataGridExample(23.2, 789, true, "another test string")
            };

            ClassWithFuncList = new List<ClassWithFuncExample>
            {
                new ClassWithFuncExample(-2.0, 3),
                new ClassWithFuncExample(22.9, 653)
            };

            ClassWithFuncList[0].FuncToRun = new Func<DateTime, bool>((x) => { MessageBox.Show($"Func run at {x}."); return true; });
            ClassWithFuncList[1].FuncToRun = new Func<DateTime, bool>((x) => { MessageBox.Show($"Func run at {x}."); return true; });
        }

        public DelegateCommand<string> RunCommand { get; private set; }

        public MyEnum TestEnumToImage
        {
            get
            {
                return testEnumToImage;
            }
            set
            {
                if (testEnumToImage != value)
                {
                    testEnumToImage = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public bool BoolToImageTrue
        {
            get
            {
                return boolToImageTrue;
            }
            set
            {
                if (boolToImageTrue != value)
                {
                    boolToImageTrue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool BoolToImageFalse
        {
            get
            {
                return boolToImageFalse;
            }
            set
            {
                if (boolToImageFalse != value)
                {
                    boolToImageFalse = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public List<SimpleDataGridExample> SimpleDataGridList
        {
            get
            {
                return simpleDataGridList;
            }
            set
            {
                if (simpleDataGridList != value)
                {
                    simpleDataGridList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<ClassWithFuncExample> ClassWithFuncList
        {
            get
            {
                return classWithFuncList;
            }
            set
            {
                if (classWithFuncList != value)
                {
                    classWithFuncList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ClassWithFuncExample SelectedClassWithFunc
        {
            get
            {
                return selectedClassWithFunc;
            }
            set
            {
                if (selectedClassWithFunc != value)
                {
                    selectedClassWithFunc = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public EnumForComboBox SelectedEnumValue
        {
            get
            {
                return selectedEnumValue;
            }
            set
            {
                if (selectedEnumValue != value)
                {
                    selectedEnumValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Command that is run from a DataGrid.
        /// </summary>
        private void RunExecute(string parameter)
        {
            SelectedClassWithFunc.RunFunc();
        }
    }
}

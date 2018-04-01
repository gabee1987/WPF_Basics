using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVVM_Basics
{
    public class MVVMTest : INotifyPropertyChanged
    {
        private string mTest;
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public string Test
        {
            get
            {
                return mTest;
            }
            set
            {
                if (mTest == value)
                    return;

                mTest = value;

                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Test)));
            }
        }

        public MVVMTest()
        {
            Task.Run(async () =>
            {
                int i = 0;

                while(true)
                {
                    await Task.Delay(1000);
                    Test = (i++).ToString(); 
                }
            });
        }

        public override string ToString()
        {
            return "It's working";
        }
    }
}

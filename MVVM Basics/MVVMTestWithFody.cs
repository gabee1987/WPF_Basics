//using PropertyChanged;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVVM_Basics
{
    //[ImplementPropertyChanged]
    public class MVVMTestWithFody : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public string Test { get; set; }
            

        public MVVMTestWithFody()
        {
            Task.Run(async () =>
            {
                int i = 0;

                while (true)
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

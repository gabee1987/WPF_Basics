using System.ComponentModel;
using System.Threading.Tasks;

namespace MVVM_Basics
{
    public class MVVMTest : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public string Test { get; set; } = "My property";

        public MVVMTest()
        {
            Task.Run(async () =>
            {
                int i = 0;

                while(true)
                {
                    await Task.Delay(200);
                    Test = (i++).ToString();
                    PropertyChanged(this, new PropertyChangedEventArgs("Test"));
                }
            });
        }

        public override string ToString()
        {
            return "It's working";
        }
    }
}

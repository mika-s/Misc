using System.Diagnostics;

namespace Web
{
    public sealed class MainViewModel : ViewModel
    {
        RestTestService restTest;
        private TimeInfoClientSide timeInformation;

        public MainViewModel(RestTestService restTestService)
        {
            restTest = restTestService;
            GetCommand = new DelegateCommand<string>(GetExecute);
            PostCommand = new DelegateCommand<string>(PostExecute);
        }

        public DelegateCommand<string> GetCommand { get; private set; }
        public DelegateCommand<string> PostCommand { get; private set; }

        public TimeInfoClientSide TimeInformation
        {
            get
            {
                return timeInformation;
            }

            private set
            {
                if (timeInformation != value)
                {
                    timeInformation = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private async void GetExecute(string parameter)
        {
            TimeInfo TimeInfo = await restTest.GetTimeInfo();
            TimeInformation = new TimeInfoClientSide(TimeInfo);
        }

        private async void PostExecute(string parameter)
        {
            BlogPost blogPost = new BlogPost();
            blogPost.userId = 1;
            blogPost.title = "Test title";
            blogPost.body = "Lorem ipsum";

            Response response = await restTest.PostBlogPost(blogPost);
            Debug.WriteLine(response);
        }
    }
}

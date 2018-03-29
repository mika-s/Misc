using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Linq
{
    public sealed class MainViewModel : ViewModel
    {
        private IEnumerable<int> result;
        private IList<string> joinResult;

        public MainViewModel()
        {
            Filter1Command = new DelegateCommand<string>(Filter1Execute);
            Filter2Command = new DelegateCommand<string>(Filter2Execute);
            FilterOddCommand = new DelegateCommand<string>(FilterOddExecute);
            FilterEvenCommand = new DelegateCommand<string>(FilterEvenExecute);
            FirstCommand = new DelegateCommand<string>(FirstExecute);
            LastCommand = new DelegateCommand<string>(LastExecute);
            TakeCommand = new DelegateCommand<string>(TakeExecute);
            SkipCommand = new DelegateCommand<string>(SkipExecute);
            SkipTakeCommand = new DelegateCommand<string>(SkipTakeExecute);
            SumCommand = new DelegateCommand<string>(SumExecute);
            CountCommand = new DelegateCommand<string>(CountExecute);
            MinCommand = new DelegateCommand<string>(MinExecute);
            MaxCommand = new DelegateCommand<string>(MaxExecute);
            AverageCommand = new DelegateCommand<string>(AverageExecute);
            UnionCommand = new DelegateCommand<string>(UnionExecute);
            IntersectCommand = new DelegateCommand<string>(IntersectExecute);
            JoinCommand = new DelegateCommand<string>(JoinExecute);
        }

        public DelegateCommand<string> Filter1Command { get; private set; }
        public DelegateCommand<string> Filter2Command { get; private set; }
        public DelegateCommand<string> FilterOddCommand { get; private set; }
        public DelegateCommand<string> FilterEvenCommand { get; private set; }
        public DelegateCommand<string> FirstCommand { get; private set; }
        public DelegateCommand<string> LastCommand { get; private set; }
        public DelegateCommand<string> TakeCommand { get; private set; }
        public DelegateCommand<string> SkipCommand { get; private set; }
        public DelegateCommand<string> SkipTakeCommand { get; private set; }
        public DelegateCommand<string> SumCommand { get; private set; }
        public DelegateCommand<string> CountCommand { get; private set; }
        public DelegateCommand<string> MinCommand { get; private set; }
        public DelegateCommand<string> MaxCommand { get; private set; }
        public DelegateCommand<string> AverageCommand { get; private set; }
        public DelegateCommand<string> UnionCommand { get; private set; }
        public DelegateCommand<string> IntersectCommand { get; private set; }
        public DelegateCommand<string> JoinCommand { get; private set; }

        public IEnumerable<int> List1
        {
            get
            {
                return new List<int> { 1, 2, 3, 4, 5 };
            }
        }

        public IEnumerable<int> List2
        {
            get
            {
                return new List<int> { 1, 3, 4 };
            }
        }

        public IEnumerable<int> List3
        {
            get
            {
                return new List<int> { 1, 3, 4, 4, 3, 6 };
            }
        }

        public IEnumerable<int> Result
        {
            get
            {
                return result;
            }

            private set
            {
                if (result != value)
                {
                    result = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public IList<Person> JoinList1
        {
            get
            {
                return new List<Person>
                {
                    new Person("Peter Peterson"),
                    new Person("Anna Peterson"),
                    new Person("Lisa Anderson")
                };
            }
        }

        public IList<Pet> JoinList2
        {
            get
            {
                return new List<Pet>
                {
                    new Pet("Rex", JoinList1[0]),
                    new Pet("Snoopy", JoinList1[1]),
                    new Pet("Fido", JoinList1[2]),
                    new Pet("Lassie", JoinList1[2])
                };
            }
        }

        public IList<string> JoinResult
        {
            get
            {
                return joinResult;
            }

            private set
            {
                if (joinResult != value)
                {
                    joinResult = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Filter with query syntax.
        /// </summary>
        private void Filter1Execute(string parameter)
        {
            Result = from x in List1 where x < 3 select x ;
        }

        /// <summary>
        /// Filter with method syntax.
        /// </summary>
        private void Filter2Execute(string parameter)
        {
            Result = List1.Where(x => x > 3);
        }

        private void FilterOddExecute(string parameter)
        {
            Result = from x in List1 where x % 2 != 0 select x;
        }

        private void FilterEvenExecute(string parameter)
        {
            Result = from x in List1 where x % 2 == 0 select x;
        }

        private void FirstExecute(string parameter)
        {
            Result = new List<int> { List1.First() };
        }

        private void LastExecute(string parameter)
        {
            Result = new List<int> { List2.Last() };
        }

        private void TakeExecute(string parameter)
        {
            Result = List1.Take(2).ToList();
        }

        private void SkipExecute(string parameter)
        {
            Result = List1.Skip(2).ToList();
        }

        private void SkipTakeExecute(string parameter)
        {
            Result = List1.Skip(1).Take(2).ToList();
        }

        private void SumExecute(string parameter)
        {
            Result = new List<int> { List1.Sum() };
        }

        private void CountExecute(string parameter)
        {
            Result = new List<int> { List2.Count() };
        }

        private void MinExecute(string parameter)
        {
            Result = new List<int> { List1.Min() };
        }

        private void MaxExecute(string parameter)
        {
            Result = new List<int> { List2.Max() };
        }

        private void AverageExecute(string parameter)
        {
            Result = new List<int> { (int)List3.Average() };
        }

        private void UnionExecute(string parameter)
        {
            Result = List2.Union(List3);
        }

        private void IntersectExecute(string parameter)
        {
            Result = List1.Intersect(List2);
        }

        private void JoinExecute(string parameter)
        {
            JoinResult = (from person in JoinList1
                         join pet in JoinList2 on person.Name equals pet.Owner.Name
                         select $"{person.Name} --> {pet.Name}").ToList();
        }
    }
}

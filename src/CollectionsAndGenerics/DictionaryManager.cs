using System.Collections;
using System.Linq;

namespace CollectionsAndGenerics
{
    /// <summary>
    /// Creates, Holds and Manipulates the dictionariers
    /// </summary>
    /// <typeparam name="TKey">Key of the dictionary</typeparam>
    /// <typeparam name="TValue">Key Value of the dictionary</typeparam>
    public class DictionaryManager<TKey, TValue>
        where TKey : notnull
    {
        private readonly Dictionary<TKey, TValue> _dictionaryOfDetails = new Dictionary<TKey, TValue>();

        private enum DictionaryOperations
        {
            Quit,
            AddDetails,
            RemoveDetais,
            SearchDetails,
        }

        /// <summary>
        /// Execute the list operations according to the users choice
        /// </summary>
        public void ExecuteTheOperation()
        {
            bool stop = false;
            do
            {
                Console.WriteLine("Students Score Manager\nChoose any option to proced\n1.Add Student Details\n2.Remove Student Details\n3.Search Student Details\n4.Quit");
                bool isUserOptionInt = int.TryParse(Console.ReadLine(), out int userOption);
                DictionaryOperations dictionaryOperations = (DictionaryOperations)userOption;
                switch (dictionaryOperations)
                {
                    case DictionaryOperations.AddDetails:
                        this.AddBooks();
                        break;
                    case DictionaryOperations.RemoveDetais:
                        this.RemoveBooks();
                        break;
                    case DictionaryOperations.SearchDetails:
                        this.SearchStudnetGrade();
                        break;
                    case DictionaryOperations.Quit:
                        stop = true;
                        break;
                    default:
                        break;
                }
            }
            while (!stop);
        }

        /// <summary>
        /// Gets input from the user and adds the book titles in a list
        /// </summary>
        private void AddBooks()
        {
            bool addStudent = true;
            while (addStudent)
            {
                TKey studentNameT = this.GetTKeyAndConvertToGeneric("Add new Studnet");
                TValue studentGradeT = this.GetTValueAndConvertToGeneric(studentNameT);

                this._dictionaryOfDetails.Add(studentNameT, studentGradeT);

                Console.WriteLine($"Totally {this._dictionaryOfDetails.Count()} were Added");
                addStudent = this.IsAddAnotherDetail();
            }
        }

        /// <summary>
        /// Confirm user to add another details
        /// </summary>
        /// <returns>True if user press 1</returns>
        private bool IsAddAnotherDetail()
        {
            Console.WriteLine("Add Another Detail ?\n1.Yes\nPress any key to skip");
            string? addAnother = Console.ReadLine();
            return true ? addAnother == "1" : false;
        }

        /// <summary>
        /// Removes a specific book from the list
        /// </summary>
        private void RemoveBooks()
        {
            TKey detailToBeRemoved = this.GetTKeyAndConvertToGeneric("Remove");

            this._dictionaryOfDetails.Remove(detailToBeRemoved);

            Console.WriteLine($"Student named : {detailToBeRemoved} have been deleted");
        }

        /// <summary>
        /// Search the books from the List
        /// </summary>
        private void SearchStudnetGrade()
        {
            TKey detailToBeSearch = this.GetTKeyAndConvertToGeneric("Find");
            if (this._dictionaryOfDetails.ContainsKey(detailToBeSearch))
            {
                Console.WriteLine($"Yes the studnet named {detailToBeSearch} is Found with Grade {this._dictionaryOfDetails[detailToBeSearch]}");
            }
            else
            {
                Console.WriteLine("Student not Found");
            }
        }

        private TKey GetTKeyAndConvertToGeneric(string useCase)
        {
            Console.WriteLine($"Enter Name to {useCase}");
            return (TKey)Convert.ChangeType(Console.ReadLine(), typeof(TKey));
        }

        private TValue GetTValueAndConvertToGeneric(TKey useCase)
        {
            Console.WriteLine($"Enter Grade of the {useCase}");
            return (TValue)Convert.ChangeType(Console.ReadLine(), typeof(TValue));
        }
    }
}

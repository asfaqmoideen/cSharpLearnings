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
        private CommonMethods<TKey> _commonMethods = new CommonMethods<TKey>();
        private CommonMethods<TValue> _commonMethodsForInt = new CommonMethods<TValue>();

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
                        this.AddStudents();
                        break;
                    case DictionaryOperations.RemoveDetais:
                        this.RemoveStudent();
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
        private void AddStudents()
        {
            bool addStudent = true;
            while (addStudent)
            {
                TKey studentNameT = this._commonMethods.GetAndConvertStringToType("Student Name");
                TValue studentGradeT = this._commonMethodsForInt.GetAndConvertStringToType("Student Grade");

                this._dictionaryOfDetails.Add(studentNameT, studentGradeT);

                Console.WriteLine($"Totally {this._dictionaryOfDetails.Count()} were Added");
                addStudent = this._commonMethods.IsAddAnotherDetail("Book");
            }
        }

        /// <summary>
        /// Removes a specific book from the list
        /// </summary>
        private void RemoveStudent()
        {
            TKey detailToBeRemoved = this._commonMethods.GetAndConvertStringToType("Remove Student");

            this._dictionaryOfDetails.Remove(detailToBeRemoved);

            Console.WriteLine($"Student named : {detailToBeRemoved} have been deleted");
        }

        /// <summary>
        /// Search the books from the List
        /// </summary>
        private void SearchStudnetGrade()
        {
            TKey detailToBeSearch = this._commonMethods.GetAndConvertStringToType("Find St");
            if (this._dictionaryOfDetails.ContainsKey(detailToBeSearch))
            {
                Console.WriteLine($"Yes the studnet named {detailToBeSearch} is Found with Grade {this._dictionaryOfDetails[detailToBeSearch]}");
            }
            else
            {
                Console.WriteLine("Student not Found");
            }
        }
    }
}

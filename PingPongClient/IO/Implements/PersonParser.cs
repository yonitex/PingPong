using Common.Implements;
using IO.Abstracts;

namespace IO.Implements
{
    public class PersonParser : IInputParser<Person>
    {
        public bool TryParse(string input, out Person result)
        {
            if (input == null || input == string.Empty)
            {
                result = default(Person);
                return false;
            }

            string[] parameters = input.Split(' ');
            int age;
            if (parameters.Length != 2 || int.TryParse(parameters[1], out age))
            {
                result = default(Person);
                return false;
            }

            string name = parameters[0];
            result = new Person(name, age);
        }
    }
}

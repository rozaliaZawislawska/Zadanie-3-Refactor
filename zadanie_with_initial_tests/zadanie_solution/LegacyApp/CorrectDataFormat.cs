namespace LegacyApp;

public class CorrectDataFormat
{
    private string _firstName;
    private string _lastName;
    private string _email;

    public CorrectDataFormat(string firstName, string lastName, string email)
    {
        this._firstName = firstName;
        this._lastName = lastName;
        this._email = email;
    }

    public bool IsCorrectFormat()
    {
        if (IsEmptyData())
            return false;

        if (IsIncorrectEmailFormat())
            return false;

        return true;
    }

    private bool IsEmptyData()
    {
        if (string.IsNullOrEmpty(_firstName) || string.IsNullOrEmpty(_lastName))
        {
            return true;
        }
        return false;
    }
    
    private bool IsIncorrectEmailFormat()
    {
        if (_email.Contains("@") && _email.Contains("."))
        {
            return false;
        }

        return true;
    }
}
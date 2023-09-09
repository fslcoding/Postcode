using System;


class MainClass
{
    public static void Main(string[] args)
    {
        string postCode;
        char repeat ='y';
        //This enables the user to enter another postcode if requested
        while (repeat=='y')
        {
            //This loop will continue to ask the user to enter a postcode until a valid postcode is entered.
            do
            {
                Console.WriteLine("Enter postcode");
                postCode = Console.ReadLine();
            }
            //This loops while the postcode is invalid or the user enters an empty string
            while ((!validPostcode(postCode)) || (string.IsNullOrEmpty(postCode)));
            Console.WriteLine("Valid postcode entered");
            Console.WriteLine("Do you want to try another postcode- enter Y or N?");
            repeat = Convert.ToChar(Console.ReadLine().ToLower()); 
        }
        Console.WriteLine("End of program. Press any key to terminate");
        Console.ReadKey();
    }

    public static bool validPostcode(string postcode)
    {
        bool validPostCode = true;
        string pc = postcode.ToLower();//Changes all chars to lower case to simplify checks

        //Creates an array to allow postcode to be converted to a char array
        char[] pcChars = new char[8];
        pcChars = pc.ToCharArray();

        //Checks if first character of postcode is 'b' or 't'
        if ((pcChars[0] != 'b') || (pcChars[1] != 't'))
        {
            validPostCode = false;
        }

        //FOr 7 characters Postcode- this will check if the character in position 2 is a number 
        if (pcChars.Length == 7)
        {
            //Checks if pizza code contains a number
            if (!char.IsDigit(pcChars[2]))
            {
                validPostCode = false;
            }

            //This will check if the character at position 3 (7 char postcode) or 4 (8 char postcode) is whitespace 
            if (!char.IsWhiteSpace(pcChars[3]))
            {
                validPostCode = false;
            }

            //This will check if the character at position 4 is a digit (0-9)
            if (!char.IsDigit(pcChars[4]))
            {
                validPostCode = false;
            }

            //This will check if the last two digits are letters
            if (!(char.IsLetter(pcChars[5])) || !(char.IsLetter(pcChars[6])))
            {
                validPostCode = false;
            }
        }

        //For 8 charcater postcodes
        else if (pcChars.Length == 8)
        {
            //Checks if postcode contains numbers in positions in 2 and 3 in the array
            if ((!char.IsDigit(pcChars[2])) && (!char.IsDigit(pcChars[3])))
            {
                validPostCode = false;
            }
            //This will check if the character at position 3 (7 char postcode) or 4 (8 char postcode) is whitespace 
            if (!char.IsWhiteSpace(pcChars[4]))
            {
                validPostCode = false;
            }

            //This will check if the character at position 4 is a digit (0-9)
            if (!char.IsDigit(pcChars[5]))
            {
                validPostCode = false;
            }

            //This will check if the last two digits are letters
            if (!(char.IsLetter(pcChars[6])) && !(char.IsLetter(pcChars[7])))
            {
                validPostCode = false;
            }

        }

        //For all other postcode length variations
        else
        {
            validPostCode = false;
        }
        return validPostCode;
    }
}

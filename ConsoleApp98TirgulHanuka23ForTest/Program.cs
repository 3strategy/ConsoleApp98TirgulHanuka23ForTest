namespace ConsoleApp98TirgulHanuka23ForTest
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Select Question to run:");
            int n = int.Parse(Console.ReadLine());
            if (n == 2) MainQ2(); // 😀 switch -מוגש מטעם העמותה לביטול ה
            else if (n == 3) MainQ3();
            else if (n == 4) MainQ4();
            else if (n == 5) MainQ5();
            else if (n == 6) MainQ6();
            else if (n == 8) MainQ8();
            else if (n == 9) MainQ9(); 
        }

        #region Q2
        static void MainQ2()
        {
            int prev1 = -1, prev2 = -1, cur; //לשמירת היסטוריה
                                             // הקצאת ערכים מחוץ לתחום כדי לא לקבל שוויון שאינו קשור לאקראיות
            Random rnd = new Random();
            for (int i = 0; i < 30; i++)
            {
                cur = rnd.Next(0, 100); //לא כולל 100
                if (cur == prev1 + prev2) // השוואה לשני הקודמים
                    Console.WriteLine($"{cur} is the sum of {prev1} and {prev2}");
                prev2 = prev1; // (גלגול לאחור (שמירת היסטוריה
                prev1 = cur;
            }
        }

        static void MainQ2v2()
        {
            Random rnd = new Random(6);

            int prev1 = rnd.Next(0, 100);  // (הגרלת המספר ה-1 (לא כולל 100
            int prev2 = rnd.Next(0, 100);  // (הגרלת המספר ה-2 (לא כולל 100
            int cur;
            for (int i = 2; i < 30; i++)
            {
                cur = rnd.Next(0, 100); //לא כולל 100
                if (cur == prev1 + prev2) // השוואה לשני הקודמים
                    Console.WriteLine($"{cur} is the sum of {prev1} and {prev2}");
                prev2 = prev1; // (גלגול לאחור (שמירת היסטוריה
                prev1 = cur;
            }
        }
        #endregion
        #region Q3
        // For methods that simply return result of expression or have 
        // single line expression, there is a syntax shortcut using "=>".
        // For example instead of:
        //     static int Salary(int h, int s)
        //     {
        //        return h * (s >= 5 ? 55 : 45);
        //     }
        // We can use the following:
        static int Salary(int h, int s) => h * (s >= 5 ? 55 : 45);

        static void MainQ3()
        {
            double count = 0; // make at least 1 of the 2 double
            int totalSalaries = 0; // to force double arithmetics.
            while (true)
            {
                Console.WriteLine("Enter seniority and hours:");

                int seniority = int.Parse(Console.ReadLine());
                if (seniority < 0)
                    break;
                int hours = int.Parse(Console.ReadLine());
                int sal = Salary(seniority, hours); // רצוי לבצע חישוב מקדים כדי 
                                                    // כדי לא לקרוא לפונקציה פעמיים
                Console.WriteLine($"salary for sen={seniority}, " +
                    $"hours={hours} is {sal}");
                count++;
                totalSalaries += sal;
            }
            if (count > 0) // יש להימנע מחלוקה ב-0
                Console.WriteLine($"average is :{totalSalaries / count}");
        }
        #endregion
        #region Q4
        static void MainQ4()
        {
            int qtM = 0; // כמות הבנים
            double qtF = 0; // לפחות דאבל אחד כדי להבטיח חישוב בממשיים
            while (true)
            {
                Console.WriteLine("please enter baby's gender\n" +
                    "1 for male, 2 for female, 0 to exit");
                // ואינו בתכנית TryParse -הערה. וידוא מלא של תקינות הקלט מצריך שימוש ב
                int gender = int.Parse(Console.ReadLine());
                if (gender == 0)
                    break;
                else if (gender == 1)
                    qtM++;
                else if (gender == 2)
                    qtF++;
                else
                    Console.WriteLine("Invalid input. Please try again"); // וידוא חלקי של תקינות
            }
            if (qtM + qtF > 0) // avoid division by 0.
            {
                double percentBoys = Math.Round(100 * qtM / (qtM + qtF), 1);
                Console.WriteLine("\nThank you for your time");
                Console.WriteLine($"{qtM} boys were born, which are {percentBoys}% of the total");
                Console.WriteLine($"{qtF} girls were born, which are {100 - percentBoys}% of the total");
                if (qtM == qtF)
                    Console.WriteLine("same amount of boys and girls were born");
                else if (qtM > qtF)
                    Console.WriteLine("More boys were born");
                else
                    Console.WriteLine("More girls were born");
            }

        }
        #endregion
        #region Q5
        static void MainQ5()
        {
            int maxHm = int.MinValue; // ניתן גם לשים 0 בשלב זה
            int maxHf = int.MinValue;
            int count = 0;
            double sum = 0; // at least 1 double for correct average.
            while (true)
            {
                Console.WriteLine("Enter gender [M or F] and jump height: ");
                string gender = Console.ReadLine();
                if (gender == "S")
                    break;
                int h = int.Parse(Console.ReadLine());

                if (gender == "M" && h > maxHm)
                    maxHm = h;
                else if (gender == "F" && h > maxHf)
                    maxHf = h;
                sum += h; // בכל מקרה 
                count++; // פתח לספירת יתר במקרה שלא הוזן מין תקין
                         // אולם נתון במפורש שהקלט תקין

            }
            if (count > 0) // avoid division by 0.
            {
                Console.WriteLine($"Best height for men: " + maxHm);
                Console.WriteLine($"Best height for women: " + maxHf);
                Console.WriteLine($"Average jump height is: {sum / count}");
            }
        }
        #endregion
        #region Q6
        static bool IsEvenDigits(int n)
        {
            // עבודה בדרך השלילה ההנחה היא שהמספר תקין
            while (n > 0)
            {
                if (n % 2 != 0)
                    return false; // מופע ראשון של הפרה מאפשר לסיים מיידית
                                  // בשום פנים ואופן לא לסיים במקרה ההפוך עם ***
                                  // *** else return true  
                n /= 10; // חיתוך ספרה ימנית
            }
            return true; // (הנחת המוצא שהמספק תקין אושרה (לא הופרכה
        }

        static bool IsDiffDigits(int n)
        {
            int rD = n % 10;
            int mD = n / 10 % 10;
            int lD = n / 100;
            // חייבים לבדוק את כל הקומבינציות לבחירת 2 מספרים מבין 3
            return rD != mD && mD != lD && rD != lD;
        }

        static void MainQ6()
        {
            int max = int.MinValue;
            while (true)
            {
                Console.WriteLine("Enter a 3 digit number");
                int n = int.Parse(Console.ReadLine());
                if (n > 999 || n < 100) // תנאי עצירת קלט
                    break;
                if (IsEvenDigits(n) && IsDiffDigits(n) && n > max)
                    max = n;
            }
            if (max == int.MinValue) // סימן שלא נקלט אף מספר מתאים
                Console.WriteLine("None of the numbers matched constraints");
            else
                Console.WriteLine("The maximal number which met all constraints was: " + max);
        }
        #endregion
        #region Q8
        /// <summary>
        /// ספירת כמות הספרות במספר
        /// </summary>
        /// <returns>כמות ספרות</returns>
        static int CountDigits(int n)
        {   // פעולת עזר
            int count = 0;
            while (n > 0)
            {
                count++; // ספירת כמות הספרות
                n /= 10;
            }
            return count;
        }

        /// <summary>
        /// היפוך סדר הספרות במספר
        /// </summary>
        /// <returns>מספר הפוך</returns>
        static int Reverse(int n)
        {   // פעולת עזר
            int rev = 0;
            while (n > 0)
            {
                rev = rev * 10 + n % 10; // הוספת הספרה הבאה  
                n /= 10;
            }
            return rev;
        }

        static int SwitchDigits(int n)
        {
            // השאלה הקשה עד כה, ולכן השתמשתי במספר פונקציות
            // ניתן כמובן לחשוב עוד שעה ולמצוא אלגוריתם 
            // שיעשה הכל במעבר אחד אבל זה יוצר קוד לא קריא
            // ומעלה באופן קיצוני את הסיכוי לשגיאות
            // code clarity & maintainability הבחירה בין ביצועים לקריאות 
            // היא ברוב המקרים לטובת קריאות/פשטות של הקוד
            if (CountDigits(n) % 2 != 0)
                return n;
            n = Reverse(n); // reverse all digits
                            // הסיבה להיפוך היא שבבניית המספר
                            // יתהפך שוב הסדר של כל זוג ספרות
            int newN = 0; // המספר המעובד שיוחזר
            while (n > 0)
            {
                newN = newN * 100 + n % 100; // בניית המספר ההפוך
                n /= 100; // חיתוך 2 ספרות
            }
            return newN;
        }

        static int SwitchDigits2(int n)
        {
            int orig = n; // Keep the original number to be able to return it
            int newN = 0; // The new number 
            int multiplier = 1; // Used to add the new digits to the left
            while (n > 0)
            {
                if (n<10)        // This is proof that n had an odd 
                    return orig; // number of digits.
                int d1 = n % 10;
                int d10 = n / 10 % 10;
                newN = newN + (d1 * 10 + d10) * multiplier;
                n /= 100; // Remove 2 right digits
                multiplier *= 100; // Increase the position of next digits   
            }
            return newN;
        }

        static void MainQ8()
        {
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                // תזכורת: אין שום קשר בין המשתנה שמוגדר כאן
                // לבין שם המשתנה שמוגדר בפונקציה אותה אנו מזמנים
                int nn = rnd.Next(1111, 6869); // 6868 inclusive
                Console.WriteLine($"{nn} {SwitchDigits(nn)}");
            }
        }
        #endregion
        #region Q9
        static void Classify(int n)
        {
            if (n == 0)
                Console.WriteLine("0");
            else
            {
                if (n <= 12) // רצוי לרשום תנאי פשוט ככל שניתן
                    Console.WriteLine("1st12");
                else if (n <= 24)
                    Console.WriteLine("2st12");
                else // רצוי להימנע מתנאי מיותר
                    Console.WriteLine("3rd12");

                // התנאים שלהלן אינם תלויים בתנאים שלעיל
                // כיוון שמספר יכול להיות שייך גם לאחד הטורים וגם לקבוצות 
                // שלעיל, יש להתחיל תנאי חדש
                if (n % 3 == 1)
                    Console.WriteLine("Col1");
                else if (n % 3 == 2)
                    Console.WriteLine("Col2");
                else // רצוי להימנע מתנאי מיותר
                    Console.WriteLine("Col3"); // כאשר יודעים בוודאות שאין בו צורך

                if (n % 2 == 0)
                    Console.WriteLine("Red");
                else
                    Console.WriteLine("Black");

            }
            // בשאלה המספר 0 אינו מוחרג מהזוגיים ולכן
            // היה צריך לרשום כאן את בדיקת הזוגיות
            // RED/BLACK נמנעתי רק מפני שבשאלה יש אי דיוק. יש הבדל בין  
            // לבין זוגי / אי זוגי אותו ניתן להסיק מהצבע הניטרלי של 0
            // למען הסר ספק, 0 מספר זוגי

        }
        static void MainQ9()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int n = rnd.Next(37);
                Console.WriteLine("=== " + n + " ==="); // לא נדרש אבל רצוי
                Classify(n);
            }
        }
        #endregion
    }
}
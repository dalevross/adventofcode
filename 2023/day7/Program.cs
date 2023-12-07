// See https://aka.ms/new-console-template for more information

using Microsoft.Win32.SafeHandles;


class Program
{
        static void Main(string[] args)
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }

   

    static int PartOne()
    {
        Dictionary<string,int> handsBids = new Dictionary<string, int>();
        
        string line;

        using(StreamReader sr = new StreamReader("input.txt")){

            while((line = sr.ReadLine()) != null)
            {
                string[] segments = line.Split(' ');
                handsBids.Add(segments[0],Int32.Parse(segments[1]));
            }

        }

        var totalWinnings = handsBids.OrderBy(x=>x.Key, new CardComparer())
        .Select((handBid,index) => handBid.Value * (index+1)).Sum();
    

         return totalWinnings;
    

    }

     static int PartTwo()
    {
          Dictionary<string,int> handsBids = new Dictionary<string, int>();
        
        string line;

        using(StreamReader sr = new StreamReader("input.txt")){

            while((line = sr.ReadLine()) != null)
            {
                string[] segments = line.Split(' ');
                handsBids.Add(segments[0],Int32.Parse(segments[1]));
            }

        }

        var totalWinnings = handsBids.OrderBy(x=>x.Key, new JokerCardComparer())
        .Select((handBid,index) => handBid.Value * (index+1)).Sum();
    

         return totalWinnings;
        
    }

    static int GetHandStrength(string hand)
    {
        if(hand.Distinct().Count() == 5)
            return 0;//High Card
        else if(hand.Distinct().Count() == 4)
            return 1; //One Pair
        else if(hand.Distinct().Count() == 3)
        {
            for(int i = 0;i<3;i++)
            {
                if(hand.Count(card => card == hand[i]) == 2)
                {
                    return 2;
                }
                else if(hand.Count(card => card == hand[i]) == 3)
                    return 3;
                
            }
            return -1;
            
        }  //Two Pair
        else if(hand.Distinct().Count() == 2 
        && (hand.Count(card => card == hand[0]) == 2 
        || hand.Count(card => card == hand[0]) == 3))
            return 4;//Full House
        else if(hand.Distinct().Count() == 2 
        && (hand.Count(card => card == hand[0]) == 1 
        || hand.Count(card => card == hand[0]) == 4))
            return 5;//Four of a kind
        else
            return 6;

        
    }

    public class CardComparer : IComparer<string> {
        public int Compare(string x, string y) {

            Dictionary<char,int> cardValue = new Dictionary<char, int>{
            {'2',0},
            {'3',1},
            {'4',2},
            {'5',3},
            {'6',4},
            {'7',5},
            {'8',6},
            {'9',7},
            {'T',8},
            {'J',9},
            {'Q',10},
            {'K',11},
            {'A',12}
        
            };

            if(GetHandStrength(x) != GetHandStrength(y))
                return GetHandStrength(x).CompareTo(GetHandStrength(y));
            else
            {
                if(x == y)
                    return 0;
                int i = 0;
                while(x[i]==y[i])
                {
                    i++;
                }
                return cardValue[x[i]].CompareTo(cardValue[y[i]]);
                
            }
        }
    }

    static string updateJokers(string x)
    {
        if(x == "JJJJJ")
            return x;
        string updatedX;
        char maxCard = x.Select(ch => (ch,x.Count(m => m ==ch))).Where(j => j.Item1 != 'J')
                .OrderByDescending( z => z.Item2).First().Item1;

        updatedX = x.Replace('J',maxCard);
        return updatedX;

    }


    public class JokerCardComparer : IComparer<string> {
        public int Compare(string x, string y) {

            Dictionary<char,int> cardValue = new Dictionary<char, int>{
            {'2',0},
            {'3',1},
            {'4',2},
            {'5',3},
            {'6',4},
            {'7',5},
            {'8',6},
            {'9',7},
            {'T',8},
            {'J',9},
            {'Q',10},
            {'K',11},
            {'A',12}
        
            };
            foreach (char key in cardValue.Keys)
            {
                cardValue[key]++;
            }
            cardValue['J']=0;

            string updatedX = x;
            string updatedY = y;
            
            if(x.Contains('J'))
            {
                updatedX = updateJokers(x);

            }
            
            if(y.Contains('J'))
            {
               updatedY = updateJokers(y);
            }
            if(GetHandStrength(updatedX) != GetHandStrength(updatedY))
                return GetHandStrength(updatedX).CompareTo(GetHandStrength(updatedY));
            else
            {
                if(x == y)
                    return 0;
                int i = 0;
                while(x[i]==y[i])
                {
                    i++;
                }
                return cardValue[x[i]].CompareTo(cardValue[y[i]]);
                
            }
        }
    }
}




using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int iValidCount = 0;
            using(StreamReader sr = new StreamReader("input.txt"))
            {
               
                string lines;
                lines = sr.ReadToEnd();
                string[] passports = lines.Split("\r\n\r\n");
                foreach (var passport in passports)
                {
                    bool birthYrValid = false;
                    bool issueYrValid = false;
                    bool expYrValid = false;
                    bool heightValid = false;
                    
                    string[] passportfields = passport.Split(new char[]{'\n',' ','\r'});
                    
                    if(Array.Exists(passportfields,field => field.StartsWith("byr")))
                    {
                        string birthYrField = passportfields.Where(field => field.Contains("byr")).First().Trim();
                        int birthYr = Int32.Parse(birthYrField.Split(new char[]{':'})[1]);
                        birthYrValid = (birthYr >= 1920 && birthYr <= 2002);
                    }


                
                    if(Array.Exists(passportfields,field => field.StartsWith("iyr")))
                    {
                        string issueYrField = passportfields.Where(field => field.Contains("iyr")).First().Trim();
                        int issueYr = Int32.Parse(issueYrField.Split(new char[]{':'})[1]);
                        issueYrValid = (issueYr >= 2010 && issueYr <= 2020);
                    }
                    
                    if(Array.Exists(passportfields,field => field.StartsWith("eyr")))
                    {
                        string expYrField = passportfields.Where(field => field.Contains("eyr")).First().Trim();
                        int expYr = Int32.Parse(expYrField.Split(new char[]{':'})[1]);
                        expYrValid = (expYr >= 2020 && expYr <= 2030);
                    
                    }
                    if(Array.Exists(passportfields,field => field.StartsWith("hgt")))
                    {   
                        string heightField = passportfields.Where(field => field.Contains("hgt")).First().Trim();
                        string heightString = heightField.Split(new char[]{':'})[1];
                        bool heightUnitCm = heightString.Trim().EndsWith("cm");
                        bool heightUnitIn = heightString.Trim().EndsWith("in");
                        int height = Int32.Parse(heightString.Replace("cm"," ").Replace("in",""));
                        heightValid = (heightUnitCm && height >= 150 && height <= 193)
                                        || (heightUnitIn && height >= 59 && height <= 76);
                    }

                    bool isValid = birthYrValid
                                   && issueYrValid
                                   && expYrValid
                                   && heightValid
                                   && Array.Exists(passportfields,field => Regex.IsMatch(field,@"hcl:#[0-9a-f]{6}\b"))
                                   && Array.Exists(passportfields,field => Regex.IsMatch(field,@"^ecl:(amb|blu|brn|gry|grn|hzl|oth)\b"))
                                   && Array.Exists(passportfields,field => Regex.IsMatch(field,@"^pid:[0-9]{9}\b"));

                    
                    if(isValid)
                        iValidCount++;
                    
                }
            }
            Console.WriteLine("Valid Count: {0}",iValidCount);
        }
    }
}

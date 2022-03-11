using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StepsCounterApplication.Model
{
    internal class StepsDataClass
    {
        List<UserDataClass> AllData = new List<UserDataClass>();
        List<TableUserDataClass> TableData = new List<TableUserDataClass>();

        public StepsDataClass(int daysCount)
        {
            ReadAllData(daysCount);
            ConvertToTableData(daysCount);
        }
        public List<TableUserDataClass> GetTableData()
        {
            return TableData;
        }

        public List<(int, int)> GetDataForPlot(string userName)
        {
            List<(int, int)> xy = new List<(int, int)>();
            int x = 0;
            for (int i = 0; i < AllData.Count; i++)
            {
                if (AllData[i].User == userName)
                {
                    xy.Add((x, AllData[i].Steps));
                    x += 10;
                }
            }
            return xy;
        }
        public void ReadAllData(int days)
        {
            List<UserDataClass> currentDay;
            for (int i = 1; i <= days; i++)
            {
                currentDay = IODataClass.ReadDataFromFile(Environment.CurrentDirectory+"/TestData/day"+i.ToString()+".json");
                for (int j = 0; j < currentDay.Count; j++)
                {
                    AllData.Add(currentDay[j]);
                }
            }
        }

        public void ConvertToTableData(int days)
        {
            List<UserDataClass> Data = AllData;
            while (Data.Count!=0)
            {
                int count = Data.Count, avg = 0, stepMin = 2147483647, stepMax = 0, counter = 0 ;
                TableUserDataClass Person = new TableUserDataClass();

                Person.User = Data[0].User;
                Person.Rank = Data[0].Rank;
                Person.Status = Data[0].Status;

                for (int i = 0; i<count; i++)
                {
                    if(Person.User == Data[i].User)
                    {
                        avg += Data[i].Steps;
                        counter++;
                        if(stepMin > Data[i].Steps) stepMin = Data[i].Steps;
                        if(stepMax < Data[i].Steps) stepMax = Data[i].Steps;
                        Data.RemoveAt(i);
                        i--;
                        count = Data.Count;
                    }
                }
                if(counter != 0) avg /= counter;
                Person.StepsAvg = avg;
                Person.StepsBest = stepMax;
                Person.StepsWorse = stepMin;
                TableData.Add(Person);
            }
            ReadAllData(days);
        }

    }
}

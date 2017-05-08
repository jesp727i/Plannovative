﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class JobRepository
    {
        static List<Job> jobList;
        #region Singleton
        private static volatile JobRepository instance;
        private static object synchronizationRoot = new Object();
       
        public static JobRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (synchronizationRoot)
                    {
                        if (instance == null)
                        {
                            instance = new JobRepository();

                        }
                    }
                }

                return instance;
            }
        }
        #endregion
        public JobRepository()
        {
            jobList = new List<Job>();
        }

        public void SaveJob(Job newJob)
        {
            jobList.Add(newJob);
        }

        public List<Job> GetList()
        {
            return jobList;
        }
        public Job GetLatestJob()
        {
            return jobList[jobList.Count - 1];
        }

        internal Job UpdateRepJob(int id, string name, string description, DateTime deadline, string priceType, double price)
        {
            throw new NotImplementedException();
            Job job = jobList.Where(n => n.opgaveID = id);
        }
    }
}

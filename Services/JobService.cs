using MinimalAPIProjectWith.Net6.Models;
using MinimalAPIProjectWith.Net6.Repositories;

namespace MinimalAPIProjectWith.Net6.Services
{
    public class JobService : IJobService
    {
        public Job CreateJob(Job job)
        {
            job.Id = JobRepository.Jobs.Count + 1;
            JobRepository.Jobs.Add(job);
            return job;
        }

        public Job GetJobById(int id)
        {
            var job = JobRepository.Jobs.FirstOrDefault(x => x.Id == id);
            if(job == null) return null;

            return job;
        }

        public List<Job> GetJobs()
        {
            return JobRepository.Jobs;
        }

        public Job UpdateJob(Job job)
        {
            var oldJob = JobRepository.Jobs.FirstOrDefault(x => x.Id == job.Id);
            if(oldJob == null) return null;

            job.Id = oldJob.Id;
            oldJob.Title = job.Title;
            oldJob.Description = job.Description;
            oldJob.Salary = job.Salary;
            
            return job;
        }

        public bool DeleteJobById(int id)
        {
            var oldJob = JobRepository.Jobs.FirstOrDefault(x => x.Id == id);
            if (oldJob == null) return false;

            return JobRepository.Jobs.Remove(oldJob);

        }
    }
}

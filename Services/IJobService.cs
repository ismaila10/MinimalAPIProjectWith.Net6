namespace MinimalAPIProjectWith.Net6.Services
{
    public interface IJobService
    {
        public Job CreateJob(Job job);
        public Job GetJobById(int id);
        public List<Job> GetJobs();
        public Job UpdateJob(Job job);
        public bool DeleteJobById(int id);
    }
}

using Nancy;
using MongoDB.Driver;
using MongoDB.Bson;
using Nancy.ModelBinding;

namespace NancyDemo
{
    public class TaskModule: NancyModule
    {
        private readonly IMongoCollection<Task> _tasks;

        public TaskModule(IMongoCollection<Task> tasks)
            : base("/api") 
        {
            _tasks = tasks;

            Get["/tasks"] = GetTask;
            Post["/tasks"] = AddTask;
            
        }

        private Response GetTask(dynamic parameters)
        {
            return Response.AsJson(_tasks.Find("{}").ToListAsync().Result.ToJson());
        }

        private Response AddTask(dynamic parameters)
        {
            var model = this.Bind<Task>();

            if (model.Text == string.Empty)
            {
                return HttpStatusCode.BadRequest;
            }

            _tasks.InsertOneAsync(model);

            return HttpStatusCode.OK;
        }
    }
}
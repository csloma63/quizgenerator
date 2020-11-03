using Autofac;
using System.Reflection;
using System.Linq;
using QuizLibrary;

namespace QuizGenerator
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<Quiz>().As<IQuiz>().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.Load("QuizLibrary"))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}

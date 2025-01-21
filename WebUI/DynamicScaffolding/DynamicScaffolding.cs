using WebUI.Models;
using WebUI.Repository;

namespace WebUI.DynamicScaffolding
{
    public class DynamicScaffolding
    {
        private readonly EntityRepository _entityRepository;
        public DynamicScaffolding(EntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        } 


        public void GenerateCode(string solutionPath, string schemaFolderPath)
        {
            var entities = _entityRepository.GetAll();

            foreach (var entity in entities)
            {
                GenerateRepository(solutionPath, entity, schemaFolderPath);
                //GenerateService(solutionPath, entity, schemaFolderPath);
                //GenerateController(solutionPath, entity, schemaFolderPath);
            }
        }

        private void GenerateRepository(string solutionPath, Entity entity, string schemaFolderPath)
        {
            string template = File.ReadAllText(Path.Combine(schemaFolderPath, "Repository.txt"));
            string folderPath = Path.Combine(solutionPath, $"DataAccess/Concrete/{entity.Name}");
            string outputPath = Path.Combine(folderPath, $"{entity.Name}Repository.cs");

            // Klasör mevcut değilse oluştur
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string code = template.Replace("{{EntityName}}", entity.Name);
            File.WriteAllText(outputPath, code);

            Console.WriteLine($"Generated Repository for {entity.Name}: {outputPath}");
        }
        //private static void GenerateService(string solutionPath, Entity entity, string schemaFolderPath)
        //{
        //    string template = File.ReadAllText(Path.Combine(schemaFolderPath, "ServiceTemplate.txt"));
        //    string outputPath = Path.Combine(solutionPath, "Business", $"{entity.Name}Service.cs");

        //    string code = template.Replace("{{EntityName}}", entity.Name);
        //    File.WriteAllText(outputPath, code);

        //    Console.WriteLine($"Generated Service for {entity.Name}: {outputPath}");
        //}

        //private static void GenerateController(string solutionPath, Entity entity, string schemaFolderPath)
        //{
        //    string template = File.ReadAllText(Path.Combine(schemaFolderPath, "ControllerTemplate.txt"));
        //    string outputPath = Path.Combine(solutionPath, "Controllers", $"{entity.Name}Controller.cs");

        //    string code = template.Replace("{{EntityName}}", entity.Name);
        //    File.WriteAllText(outputPath, code);

        //    Console.WriteLine($"Generated Controller for {entity.Name}: {outputPath}");
        //}
    }
}

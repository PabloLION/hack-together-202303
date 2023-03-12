using Azure;
using Azure.AI.Language.QuestionAnswering;
using System;
using dotenv.net;





namespace question_answering
{
  class Program
  {
    static IDictionary<string, string> envVars = DotEnv.Fluent()
      .WithoutExceptions()
      .WithEnvFiles("../../.env.secret")
      .WithoutTrimValues()
      .WithDefaultEncoding()
      .WithoutOverwriteExistingVars()
      .WithoutProbeForEnv()
      .Read();

    static void Main(string[] args)
    {
      foreach (KeyValuePair<string, string> envVar in Program.envVars)
      {
        Console.WriteLine($"{envVar.Key} is {envVar.Value}");
      }

      Uri endpoint = new Uri($"https://{Program.envVars["ENDPOINT"]}.api.cognitive.microsoft.com/");
      AzureKeyCredential credential = new AzureKeyCredential($"{Program.envVars["LANGUAGE-RESOURCE-KEY"]}");
      string projectName = $"{Program.envVars["PROJECT-NAME"]}";
      string deploymentName = "production";

      string question = "How long should my Surface battery last?";

      QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
      QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);

      Response<AnswersResult> response = client.GetAnswers(question, project);

      foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
      {
        Console.WriteLine($"Q:{question}");
        Console.WriteLine($"A:{answer.Answer}");
      }
    }
  }
}
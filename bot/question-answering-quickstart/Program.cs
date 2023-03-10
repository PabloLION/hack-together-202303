using Azure;
using Azure.AI.Language.QuestionAnswering;
using System;

namespace question_answering
{
  class Program
  {
    static void Main(string[] args)
    {

      Uri endpoint = new Uri("https://{YOUR-ENDPOINT}.api.cognitive.microsoft.com/");
      AzureKeyCredential credential = new AzureKeyCredential("{YOUR-LANGUAGE-RESOURCE-KEY}");
      string projectName = "{YOUR-PROJECT-NAME}";
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
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CvAlInstante.Entities
{
    public class CurriculumPdfGenerator
    {
        public static byte[] GenerarPDF(Curriculum cv)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(40);
                    page.Size(PageSizes.A4);
                    page.Content().Column(col =>
                    {
                        col.Item().Text("Curriculum Vitae").FontSize(20).Bold().AlignCenter();
                        col.Item().Text($"Nombre: {cv.FullName}").FontSize(14).Bold();
                        col.Item().Text($"Perfil Profesional: {cv.ProfesionalProfile}").FontSize(12);

                        col.Item().Text("Educación").Bold();
                        foreach (var edu in cv.Educations)
                            col.Item().Text($"- {edu.Degree} en {edu.Institution} ({edu.StartYear} - {edu.EndYear})");

                        col.Item().Text("Experiencia").Bold();
                        foreach (var exp in cv.Experiences)
                        {
                            col.Item().Text($"- {exp.Role} en {exp.Company} ({exp.StartYear} - {exp.EndYear})");
                            col.Item().Text($"  {exp.Description}");
                        }

                        col.Item().Text("Habilidades").Bold();
                        foreach (var hab in cv.Skills)
                            col.Item().Text($"- {hab.Name} (Nivel {hab.Level}/5)");
                    });
                });
            });

            return document.GeneratePdf();
        }
    }
}

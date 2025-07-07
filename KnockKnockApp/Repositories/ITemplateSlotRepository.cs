using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Repositories
{
    public interface ITemplateSlotRepository
    {
        public Task<List<TemplateSlot>> GetTemplateSlotsByTemplateIdAsync(int templateId);
    }
}

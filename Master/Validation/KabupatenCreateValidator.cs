using FluentValidation;
using Master.ParamRequest;

namespace Master.Validation
{
    public class KabupatenCreateValidator : AbstractValidator<KabupatenCreateReq>
    {
        public KabupatenCreateValidator()
        {
            CascadeMode = CascadeMode.Continue;
            RuleFor(x=> x.KabupatenName).NotNull();
            RuleFor(x=> x.ProvinsiId).NotNull().GreaterThan(0);
            RuleFor(x=> x.KabupatenFl).NotNull();
        }
    }
}

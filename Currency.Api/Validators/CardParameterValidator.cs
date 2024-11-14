using Currency.Api.Parameter;
using FluentValidation;
using Microsoft.VisualBasic;

namespace Currency.Api.Validators
{
    /// <summary>
    /// Card Parameter 的驗證器
    /// </summary>
    public class CardParameterValidator : AbstractValidator<CardParameter>
    {
        /// <summary>
        /// 驗證器建構式: 在這裡註冊我們要驗證的規則
        /// </summary>
        public CardParameterValidator()
        {
            this.RuleFor(card => card.Attack)
                .GreaterThanOrEqualTo(0)
                .WithName("攻擊力")
                .WithMessage("卡片的{PropertyName}不可為負數");

            this.RuleFor(card => card.Health)
                .GreaterThanOrEqualTo(0);

            this.RuleFor(card => card.Cost)
                .GreaterThanOrEqualTo(0);

            this.RuleFor(card => card.Description)
                .NotNull()
                .MaximumLength(30);

            this.RuleFor(card => card.Name)
                .NotEmpty()
                .MaximumLength(15);
        }
    }
}

///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NovumArcanum.Extensions;
using NovumArcanum.Models;
using NovumArcanum.Models.Constants;
using NovumArcanum.Models.Pages;
using NovumArcanum.Repository;

namespace NovumArcanum.Components
{
    [ViewComponent]
    public class WizardMenuNav : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly UserManager<SanctumTrustee> _userManager;
        private readonly IWizardRepository _wizardRepository;

        private bool HasSanctumPermission =>
            User.IsInRole(WizardRole.MagusAdeptus) ||
            User.IsInRole(WizardRole.MagusMagister) ||
            User.IsInRole(WizardRole.MagusPrimus);

        public WizardMenuNav(IMapper mapper, UserManager<SanctumTrustee> userManager, IWizardRepository wizardRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _wizardRepository = wizardRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var trustee = HasSanctumPermission ? await _userManager.FindByNameAsync(User.Identity.Name) : null;
            var userId = trustee != null ? trustee.Id : "";

            var wizards = await _wizardRepository.SummonAllWizards();
            var wizardDTOs = wizards.ToWizardSecretLairDTO(_mapper);
            var wizardsOrdered = wizardDTOs.OrderBy(x => x.DisplayOrder);

            var viewModel = new ViewModel
            {
                Wizards = wizardsOrdered,
                UserId = userId,
            };

            return View(viewModel);
        }

        public class ViewModel
        {
            public IEnumerable<WizardSecretLairDTO> Wizards { get; set; }
            public string UserId { get; set; }
        }
    }
}

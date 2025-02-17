using AutoMapper;
using BankSystem.Core.Entities;
using BankSystem.Service.Repository;
using BankSystem.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.App.Controllers.Admin;

public class FileTypeController(IFileTypeRepository fileTypeRepository,IMapper mapper) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index() => View(await fileTypeRepository.GetAllAsync());
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(long id)
    {
        if (id == 0)
            return View(new FileTypeVm());
        else
            return View(await fileTypeRepository.FirstOrDefaultAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(long id, FileTypeVm model)
    {
        if (id == 0)
        {
            //Data Save
            if (ModelState.IsValid)
            {
                await fileTypeRepository.InsertAsync(mapper.Map<FileType>(model));
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            //data Update
            if (ModelState.IsValid)
            {
                await fileTypeRepository.UpdateAsync(id, mapper.Map<FileType>(model));
                return RedirectToAction(nameof(Index));
            }
        }
        return View(model);
    }
    public async Task<IActionResult> Delete(long id)
    {
        if (id != 0)
        {
            await fileTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index));
    }
}

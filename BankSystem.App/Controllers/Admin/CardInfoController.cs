using AutoMapper;
using BankSystem.Core.Entities;
using BankSystem.Service.Repository;
using BankSystem.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BankSystem.App.Controllers.Admin;

public class CardInfoController(ICardInfoRepsitory cardInfoRepsitory, IMapper mapper,IFileTypeRepository fileTypeRepository) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index() => View(await cardInfoRepsitory.GetAllAsync());
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(long id)
    {
        ViewData["fileTypeId"] = fileTypeRepository.Dropdown();
        if (id == 0)
            return View(new CardInfoVm());
        else
            return View(await cardInfoRepsitory.FirstOrDefaultAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(long id, CardInfoVm model)
    {
        try
        {
            if (id == 0)
            {
                
                    if (model.FileContent != null && model.FileContent.Length > 0)
                    {
                        // Convert the file to a base64 string
                        using (var memoryStream = new MemoryStream())
                        {
                            await model.FileContent.CopyToAsync(memoryStream);
                            var fileBytes = memoryStream.ToArray();
                            model.CardFile = Convert.ToBase64String(fileBytes); // Store the base64 string
                        }
                        // Map the ViewModel to the Entity (using AutoMapper)
                        var cardInfo = mapper.Map<CardInfo>(model);
                        await cardInfoRepsitory.InsertAsync(cardInfo);
                        return RedirectToAction(nameof(Index));

                    }


               

                return View(model);
            }
            else
            {
                //data Update
                
                    if (model.FileContent != null && model.FileContent.Length > 0)
                    {
                        // Convert the file to a base64 string
                        using (var memoryStream = new MemoryStream())
                        {
                            await model.FileContent.CopyToAsync(memoryStream);
                            var fileBytes = memoryStream.ToArray();
                            model.CardFile = Convert.ToBase64String(fileBytes); // Store the base64 string
                        }
                        // Map the ViewModel to the Entity (using AutoMapper)
                        var cardInfo = mapper.Map<CardInfo>(model);
                        await cardInfoRepsitory.UpdateAsync(id, cardInfo);
                        return RedirectToAction(nameof(Index));
                    }

                
            }
            return View(model);
        }
        catch (Exception ex)
        {

            throw;
        }
       
    }
    public async Task<IActionResult> Delete(long id)
    {
        if (id != 0)
        {
            await cardInfoRepsitory.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index));
    }
}

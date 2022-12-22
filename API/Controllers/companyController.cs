using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using EStore.API.Data;
using EStore.API.Data.Models;
using EStore.API.Data.Services;
using EStore.API.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using API.Controllers;

namespace EStore.Controllers
{
    [ApiController]
    public class companyController : baseApiContoller
    {
        private AppDbContext _context;
        private UserManager<user> _user;

        public companyController(AppDbContext context, UserManager<user> user)
        {
            _context = context;
            _user = user;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("Add_Item")]
        public async Task<ActionResult> AddItem(itemVm _itemVm)
        {
            var user = await _user.FindByNameAsync(User.Identity.Name);
            var _item = new item
            {
                Short_Name = _itemVm.Short_Name,
                Short_Description = _itemVm.Short_Description,
                Price = _itemVm.Price,
                Quantity = 0,
                Is_Active = 0,
                Main_Photo = _itemVm.Main_Photo,
                Main_Category = await _context.CATEGORY
                    .Where(o => o.Id == _itemVm.Category_Id)
                    .Select(o => o.mainCategory_Id)
                    .FirstOrDefaultAsync(),
                Category_Id = _itemVm.Category_Id,
                Company_Id = user.Company_Id
            };
            await _context.ITEMS.AddAsync(_item);
            await _context.SaveChangesAsync();
            return Ok(_item.Id);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("Add_Item_Photoes")]
        public async Task<ActionResult> AddItemPhotoes(itemPhotoesVm _itemPhotoesVm)
        {
            var user = await _user.FindByNameAsync(User.Identity.Name);
            var item = await _context.ITEMS
                .Where(o => o.Id == _itemPhotoesVm.Item_Id)
                .FirstOrDefaultAsync();
            if (item.Company_Id != user.Company_Id)
            {
                return Unauthorized();
            }
            var _itemPhoto = new item_Photoes
            {
                Item_Id = _itemPhotoesVm.Item_Id,
                item_Logo = _itemPhotoesVm.item_Logo
            };
            await _context.ITEM_PHOTOES.AddAsync(_itemPhoto);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("Add_Item_Details")]
        public async Task<ActionResult> AddItemDetails(itemDetailsVm _itemDetailsVm)
        {
            var user = await _user.FindByNameAsync(User.Identity.Name);
            var item = await _context.ITEMS
                .Where(o => o.Id == _itemDetailsVm.Item_Id)
                .SingleOrDefaultAsync();
            if (item == null)
            {
                return Unauthorized("there's no item mannn");
            }
            else if (item.Company_Id != user.Company_Id)
            {
                return Unauthorized();
            }
            var _itemDetails = new item_Details
            {
                Item_Id = _itemDetailsVm.Item_Id,
                Size = _itemDetailsVm.Size,
                Colour = _itemDetailsVm.Colour,
                Price = _itemDetailsVm.Price,
                Sale = 0
            };
            await _context.ITEM_DETAILS.AddAsync(_itemDetails);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPut("Activate_Item")]
        public async Task<ActionResult> ActivateItem(long item_Id)
        {
            var user = await _user.FindByNameAsync(User.Identity.Name);
            var item = await _context.ITEMS.Where(o => o.Id == item_Id).FirstOrDefaultAsync();
            if (item == null)
            {
                return Unauthorized("there's no item mannn");
            }
            else if (item.Company_Id != user.Company_Id)
            {
                return Unauthorized();
            }
            else if (item.Is_Active == 1)
            {
                return BadRequest("Already Active");
            }
            var item_Details = await _context.ITEM_DETAILS
                .Where(o => o.Item_Id == item_Id)
                .FirstOrDefaultAsync();
            if (item_Details == null)
            {
                return BadRequest("Can't activate an item, cos there's no details");
            }
            item.Is_Active = 1;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPut("Deactivate_Item")]
        public async Task<ActionResult> DeactivateItem(long item_Id)
        {
            var user = await _user.FindByNameAsync(User.Identity.Name);
            var item = await _context.ITEMS.Where(o => o.Id == item_Id).FirstOrDefaultAsync();
            if (item == null)
            {
                return Unauthorized("there's no item mannn");
            }
            else if (item.Company_Id != user.Company_Id)
            {
                return Unauthorized();
            }
            else if (item.Is_Active == 0)
            {
                return BadRequest("Already Deactived");
            }
            var item_Details = await _context.ITEM_DETAILS
                .Where(o => o.Item_Id == item_Id)
                .FirstOrDefaultAsync();
            if (item_Details == null)
            {
                return BadRequest("Can't activate an item, cos there's no details");
            }
            item.Is_Active = 0;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

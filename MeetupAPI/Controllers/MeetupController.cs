using AutoMapper;
using MeetupAPI.Data;
using MeetupAPI.Data.Models;
using MeetupAPI.View.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MeetupAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MeetupController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly MeetupDbContext context;
        public MeetupController(IMapper mapper, MeetupDbContext context) => (this.mapper, this.context) = (mapper, context);

        [HttpGet]
        public async Task<IEnumerable<GetAllMeetupViewModel>> Get()
        {
            List<Meetup> meetupsh = await context.Meetups.Select(GetMeetup()).ToListAsync();

            return mapper.Map<List<GetAllMeetupViewModel>>(meetupsh);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetByIdMeetupViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            Meetup? meetup = await context.Meetups.Select(GetMeetup()).FirstOrDefaultAsync(src => src.Id == id);

            return meetup == null ? NotFound() : Ok(mapper.Map<GetByIdMeetupViewModel>(meetup));
        }

        [HttpPost]
        public async Task<IActionResult> Create(GetByIdMeetupViewModel meetupViewModel)
        {
            Meetup meetup = mapper.Map<Meetup>(meetupViewModel);

            await context.Meetups.AddAsync(meetup);
            await context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetById), new { id = meetup.Id }, meetupViewModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetByIdMeetupViewModel), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(int id, GetByIdMeetupViewModel meetupViewModel)
        {
            int meetupId = await context.Meetups.Select(src => src.Id).FirstOrDefaultAsync(src => src == id);

            if (meetupId == 0) return NotFound();

            Meetup meetup = mapper.Map<Meetup>(meetupViewModel);

            meetup.Id = id;

            context.Entry(meetup).State = EntityState.Modified;

            Address address = meetup.Address;
            address.Id = id;
            context.Entry(address).State = EntityState.Modified;


            MeetupController meetupController = new(mapper, context);

            List<Plan> oldPlan = await context.Plans.Where(src => src.MeetupId == id).Select(src => new Plan { Id = src.Id, MeetupId = id }).ToListAsync();
            List<Plan> newPlan = meetup.Plan.Select(src => new Plan { Id = src.Id, Item = src.Item, MeetupId = id }).ToList();
            int minLength = Math.Min(oldPlan.Count, newPlan.Count);
            for (int i = 0; i < minLength; i++)
            {
                newPlan[i].Id = oldPlan[i].Id;
            }

            meetupController.UpdateDatabase(oldPlan, newPlan);

            List<Organizer> oldOrganizers = await context.Organizers.Where(src => src.MeetupId == id).Select(src => new Organizer { Id = src.Id, MeetupId = id }).ToListAsync();
            List<Organizer> newOrganizers = meetup.Organizers.Select(src => new Organizer { Id = src.Id, FirstName = src.FirstName, LastName = src.LastName, OrganizationOrTopic = src.OrganizationOrTopic, MeetupId = id }).ToList();
            int minValue = Math.Min(oldOrganizers.Count, newOrganizers.Count);
            for (int i = 0; i < minValue; i++)
            {
                newOrganizers[i].Id = oldOrganizers[i].Id;
            }

            meetupController.UpdateDatabase(oldOrganizers, newOrganizers);

            List<Speaker> oldSpeakers = await context.Speakers.Where(src => src.MeetupId == id).Select(src => new Speaker { Id = src.Id, MeetupId = id }).ToListAsync();
            List<Speaker> newSpeakers = meetup.Speakers.Select(src => new Speaker { Id = src.Id, FirstName = src.FirstName, LastName = src.LastName, OrganizationOrTopic = src.OrganizationOrTopic, MeetupId = id }).ToList();
            int min = Math.Min(oldSpeakers.Count, newSpeakers.Count);
            for (int i = 0; i < min; i++)
            {
                newSpeakers[i].Id = oldSpeakers[i].Id;
            }

            meetupController.UpdateDatabase(oldSpeakers, newSpeakers);

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            int meetupId = await context.Meetups.Select(src => src.Id).FirstOrDefaultAsync(src => src == id);

            if (meetupId == 0) return NotFound();

            context.Meetups.Remove(new Meetup { Id = id });

            context.SaveChanges();

            return NoContent();
        }

        private void UpdateDatabase<O, N>(List<O> oldData, List<N> newData)
        {
            for (int i = 0, n = newData.Count, o = oldData.Count; n > 0 || o > 0; i++, n--, o--)
            {
                if (n > 0 && o > 0)
                {
                    context.Entry(newData[i]!).State = EntityState.Modified;
                }
                else if (o > 0)
                {
                    context.Entry(oldData[i]!).State = EntityState.Deleted;
                }
                else
                {
                    context.Add(newData[i]!);
                }
            }
        }

        private static Expression<Func<Meetup, Meetup>> GetMeetup()
        {
            return meetup => new Meetup
            {
                Id = meetup.Id,
                Title = meetup.Title,
                Topic = meetup.Topic,
                Description = meetup.Description,
                DateTime = meetup.DateTime,
                Address = new Address { City = meetup.Address.City, Street = meetup.Address.Street, House = meetup.Address.House },
                Plan = meetup.Plan.Select(o => new Plan { Item = o.Item }).ToList(),
                Organizers = meetup.Organizers.Select(o => new Organizer { FirstName = o.FirstName, LastName = o.LastName, OrganizationOrTopic = o.OrganizationOrTopic }).ToList(),
                Speakers = meetup.Speakers.Select(o => new Speaker { FirstName = o.FirstName, LastName = o.LastName, OrganizationOrTopic = o.OrganizationOrTopic }).ToList()
            };
        }
    }
}
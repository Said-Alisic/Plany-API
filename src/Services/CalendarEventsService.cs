using API.Common.Dto;
using API.Common.Helpers.AutoMapper;
using API.Common.Interfaces;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualBasic;

namespace API.Services
{
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.

    public class CalendarEventsService : ICalendarEventsService
    {
        private readonly ApiDbContext _apiDbContext;

        public CalendarEventsService(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext ?? throw new ArgumentNullException(nameof(apiDbContext));

            _apiDbContext.Database.EnsureCreated();
        }

        public async Task<CalendarEvent> GetCalendarEventAsync(Guid calendarEventId)
        {
            return await _apiDbContext.CalendarEvents.FindAsync(calendarEventId);
        }

        public async Task<IEnumerable<CalendarEvent>> GetCalendarEventsAsync(DateTime? date)
        {
            IQueryable<CalendarEvent> query = _apiDbContext.CalendarEvents;

            if (date.HasValue)
            {
                query = query.Where(item => item.DateAndTime.Date.Equals(date));
            }

            return await query.ToArrayAsync() ?? Array.Empty<CalendarEvent>();
        }

        public async Task<IEnumerable<User?>> GetCalendarEventParticipantsAsync(
            Guid calendarEventId
        )
        {
            IEnumerable<Guid> participantsUserIds =
                await _apiDbContext
                    .Participants.Where(item => item.CalendarEventId.Equals(calendarEventId))
                    .Select(item => item.UserId)
                    .ToListAsync() ?? null;

            // // If participants' userIds were found, search database for those users and add it to the response
            return await _apiDbContext
                    .Users.Where(item => participantsUserIds.Contains(item.Id))
                    .ToListAsync() ?? null;
        }

        public async Task<CreateCalendarEventDto> CreateCalendarEventAsync(
            CalendarEvent calendarEvent,
            string[]? userIds
        )
        {
            EntityEntry createdCalendarEvent = await _apiDbContext.CalendarEvents.AddAsync(
                calendarEvent
            );

            List<Participant> participants = new List<Participant>();

            if (userIds != null && !userIds.Any())
            {
                participants = userIds
                    .Distinct()
                    .Select(
                        userId =>
                            new Participant
                            {
                                CalendarEventId = calendarEvent.Id,
                                UserId = Guid.Parse(userId)
                            }
                    )
                    .ToList();

                await _apiDbContext.Participants.AddRangeAsync(participants);
            }

            await _apiDbContext.SaveChangesAsync();

            return new CreateCalendarEventDto
            {
                CalendarEvent = createdCalendarEvent.Entity as CalendarEvent,
                Participants = participants
            };
        }

        public async Task DeleteCalendarEventAsync(CalendarEvent calendarEvent)
        {
            // Prepare deletion of CalendarEvent in the db
            _apiDbContext.CalendarEvents.Remove(calendarEvent);

            try
            {
                // Save changes to db
                await _apiDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new ApplicationException(
                    "An error occured while saving changes to the database.",
                    e
                );
            }
        }
    }
}

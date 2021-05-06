﻿using AllMixedUp.Data;
using AllMixedUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Services
{
    public class MessageService
    {
        private readonly Guid _userId;
        public MessageService(Guid userId)
        {
            _userId = userId;
        }

        //CREATE method
        public bool CreateMessage(MessageCreate model)
        {
            var entity =
                new Message()
                {
                    OwnerId = _userId,
                    MessageID = model.MessageID,
                    UserID = model.UserID,
                    Body = model.Body,
                    CreatedDate = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Message.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //ADD Method
        public IEnumerable<MessageListItem> GetMessage()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Message
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MessageListItem
                                {
                                    MessageID = e.MessageID,
                                    UserID = e.UserID,
                                    Body = e.Body,
                                    CreatedDate = e.CreatedDate
                                }
                        );

                return query.ToArray();
            }
        }

        //Detail 
        public MessageDetail GetMessageById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Message
                        .Single(e => e.MessageID == id && e.OwnerId == _userId);
                return
                    new MessageDetail
                    {
                        MessageID = entity.MessageID,
                        UserID = entity.UserID,
                        Body = entity.Body,
                        CreatedDate = entity.CreatedDate,
                    };
            }
        }

        //UPDATE  ***don't think messages should be updated?"
        public bool UpdateMessage(MessageEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Message
                        .Single(e => e.MessageID == model.MessageID && e.OwnerId == _userId);

                entity.Body = model.Body;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteMessage(int messageID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Message
                        .Single(e => e.MessageID == messageID && e.OwnerId == _userId);

                ctx.Message.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
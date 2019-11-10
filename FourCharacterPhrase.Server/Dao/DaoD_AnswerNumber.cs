using FourCharacterPhrase.Server.Common;
using FourCharacterPhrase.Server.Framework;
using FourCharacterPhrase.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourCharacterPhrase.Server.Dao
{
    public class DaoD_AnswerNumber : DaoBase
    {
        public List<AnswerNumberEntity> GetAnswerNumberList()
        {
            return this.context.AnswerNumberEntitys.ToList();
        }

        public AnswerNumberEntity GetAnswerNumber(string Name)
        {
            return this.context.AnswerNumberEntitys.Find(Name);
        }

        public void Save(AnswerNumberEntity data)
        {
            var saveBeforeData = GetAnswerNumber(data.Name);
            EnmEditMode editMode;

            if (saveBeforeData != null)
            {
                editMode = EnmEditMode.Insert;
            }
            else
            {
                editMode = EnmEditMode.Update;
            }

            var contexForSave = DB.CreateAppDbContextForSave();
            contexForSave.Entry(data).State = ConvertEnmEditModeToEntityState(editMode);
        }
    }
}

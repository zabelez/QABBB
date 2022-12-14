using QABBB.API.Models.Project.TesterUploadedFile;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class TesterUploadedFileAssembler
    {

        public TesterUploadedFileDTO toTesterUploadedFileDTO(TesterUploadedFile testeruploadedfile) {

            TesterUploadedFileDTO testeruploadedfileDTO = new TesterUploadedFileDTO();
            testeruploadedfileDTO.IdTesterUploadedFile = testeruploadedfile.IdTesterUploadedFile;
            testeruploadedfileDTO.IdProject = testeruploadedfile.IdProject;
            testeruploadedfileDTO.Name = testeruploadedfile.Name;
            testeruploadedfileDTO.Url = testeruploadedfile.Url;
            
            return testeruploadedfileDTO;
        }

        public TesterUploadedFile toTesterUploadedFile(TesterUploadedFile testeruploadedfile, TesterUploadedFileEditDTO testeruploadedfileEditInputDTO){
            testeruploadedfile.IdTesterUploadedFile = testeruploadedfileEditInputDTO.IdTesterUploadedFile;
            testeruploadedfile.IdProject = testeruploadedfileEditInputDTO.IdProject;
            testeruploadedfile.Name = testeruploadedfileEditInputDTO.Name;
            testeruploadedfile.Url = testeruploadedfileEditInputDTO.Url;

            return testeruploadedfile;
        }

        public List<TesterUploadedFileDTO> toTesterUploadedFileDTO(IEnumerable<TesterUploadedFile> companies) {

            List<TesterUploadedFileDTO> testeruploadedfileDTO = new List<TesterUploadedFileDTO>();

            foreach (TesterUploadedFile testeruploadedfile in companies) {
                testeruploadedfileDTO.Add(toTesterUploadedFileDTO(testeruploadedfile));
            }

            return testeruploadedfileDTO;
        }

        public TesterUploadedFile toTesterUploadedFile(TesterUploadedFileInputDTO testeruploadedfileInputDTO) {

            TesterUploadedFile testeruploadedfile = new TesterUploadedFile();
            testeruploadedfile.IdProject = testeruploadedfileInputDTO.IdProject;
            testeruploadedfile.Name = testeruploadedfileInputDTO.Name;
            testeruploadedfile.Url = testeruploadedfileInputDTO.Url;

            return testeruploadedfile;
        }
    }
}


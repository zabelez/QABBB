using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class TesterUploadedFileRepository
    {
        private readonly QABBBContext _context;

        public TesterUploadedFileRepository(QABBBContext context) {
            _context = context;
        }

        public List<TesterUploadedFile> list(){
            return _context.TesterUploadedFiles.ToList();
        }

        public bool add(TesterUploadedFile testerUploadedFile) {
            _context.TesterUploadedFiles.Add(testerUploadedFile);
            _context.SaveChanges();
            return true;
        }

        public bool save(TesterUploadedFile testerUploadedFile){
            _context.Entry(testerUploadedFile).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public TesterUploadedFile? findById(int id) {
            return _context.TesterUploadedFiles.FirstOrDefault();
        }

        public bool edit(TesterUploadedFile testerUploadedFile){
            _context.Entry(testerUploadedFile).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool delete(TesterUploadedFile testerUploadedFile){
            _context.TesterUploadedFiles.Remove(testerUploadedFile);
            _context.SaveChanges();
            return true;
        }
    }
}


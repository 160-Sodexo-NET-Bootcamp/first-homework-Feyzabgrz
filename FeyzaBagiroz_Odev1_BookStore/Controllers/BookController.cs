using FeyzaBagiroz_Odev1_BookStore.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FeyzaBagiroz_Odev1_BookStore.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public List<Book> bookList;
        public BookController()
        {
            //constructor
            bookList = new List<Book>();
            bookList.Add(new Book { Id = 1, BookSerialNo = "9786053604099", BookName = "Anna Karenina", Author = "Lev N. Tolstoy", PageCount = 1500, PublishDate = 2020 });
            bookList.Add(new Book { Id = 2, BookSerialNo = "9789759064310", BookName = "Ferrarisini Satan Bilge", Author = "Robin Sharma", PageCount = 200, PublishDate = 1996 });
            bookList.Add(new Book { Id = 3, BookSerialNo = "9789750708619", BookName = "Aşk ve Gurur", Author = "Jane Austen", PageCount = 444, PublishDate = 2018 });
            bookList.Add(new Book { Id = 4, BookSerialNo = "9789753638029", BookName = "Kürk Mantolu Madonna", Author = "Sabahattin Ali", PageCount = 160, PublishDate = 2019 });
            bookList.Add(new Book { Id = 5, BookSerialNo = "9789754589023", BookName = "Suç ve Ceza", Author = "Fyodor Mihailoviç Dostoyevski", PageCount = 687, PublishDate = 2020 });
            bookList.Add(new Book { Id = 6, BookSerialNo = "9789750714948", BookName = "Notre Dame'ın Kamburu ", Author = "Victor Hugo", PageCount = 656, PublishDate = 2012 });
        }

        //******************** HttpPost ile tum kayitlari listeleme ***********************//


        [HttpPost]
        public ActionResult<List<Book>> GetBookList()
        {
            if (bookList == null)
            {
                return NotFound("");
            }

            return bookList;

        }


        //******************** HttpGet ile FromRoute ve FromQuery kullanarak 2 farkli api ile girilen id nin detaylarini gostermek ***********************//

        //[HttpGet("{id}")] //FromRoute
        //public IActionResult GetBookById(int id)
        //{


        //    var book = bookList.Where(x => x.Id == id).FirstOrDefault();
        //    if (book is null)
        //    {
        //        return NotFound("Bulunamadı"); //400
        //    }
        //    return Ok(book);   
        //}


        //***************** HttpGet ile FromRoute ve FromQuery kullanarak 2 farkli api ile girilen id nin detaylarini gostermek *********************//


        [HttpGet]  //FromQuery
        public IActionResult GetBookById([FromQuery] int id)
        {

            var book = bookList.Where(x => x.Id == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound("Bulunamadı"); //400
            }
            return Ok(book);
        }

        //***************** HttpPost ile FromBody kullanarak listeye yeni bir kayit eklemek************************//

        //[HttpPost]
        //public ActionResult<List<Book>> AddBook([FromBody] Book book)
        //{

        //    if (book != null)
        //    {
        //        return Ok();
        //    }
        //    if (book == null)
        //    {
        //        return Ok("Book is Not Found");
        //    }

        //    bookList.Add(book);
        //    return bookList;

        //}

        //*************** HttpPut ile mevcut kaydi guncellemek ***************//


        [HttpPut]
        public ActionResult<List<Book>> UpdateBook(int id, [FromBody] Book book)
        {
            var result = bookList.Where(x => x.Id == id).FirstOrDefault();

            if (result is null)
            {
                return Ok("Not Found");
            }

            result.BookSerialNo = book.BookSerialNo;
            result.BookName = book.BookName;
            result.PageCount = book.PageCount;
            result.Author = book.Author;
            result.PublishDate = book.PublishDate;

            return Ok(result);

        }



        //*************** HttpDelete ile listeden kayit silmek ***************//

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var result = bookList.Where(x => x.Id == id).FirstOrDefault();

            if (result is null)
            {
                return NotFound();
            }
            bookList.Remove(result);
            return Ok(bookList);

        }
    }
}

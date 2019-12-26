using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConnectionClass
/// </summary>
public class ConnectionClass
{
   public static DataClassesDataContext dataaccess = null;
   SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\R\21-11-2016\OnlineMovieTicketbookingSystem\OnlineMovieTicketbookingSystem\App_Data\MovieTicket.mdf;Integrated Security=True");
    public static DataClassesDataContext getContext()
    {
        if (dataaccess == null)
            //return new DataClassesDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\R\21-11-2016\OnlineMovieTicketbookingSystem\OnlineMovieTicketbookingSystem\App_Data\MovieTicket.mdf;Integrated Security=True");
                return new DataClassesDataContext();
        else
            return dataaccess;
    }
    public static IEnumerable<Movie_Tbl> getMovies()
    {
        var da = getContext();
        var MovieData = from allrec in da.Movie_Tbls
                        where allrec.Status == "Active"
                        select allrec;
        return MovieData;
    }
    public static IEnumerable<Show_Tbl> ActiveMovies()
    {
        var da = getContext();
        var MovieData = from allrec in da.Show_Tbls
                        select allrec;
        return MovieData;
    }
    public static IEnumerable<Theatre_Tbl> getTheatre()
    {
        var da = getContext();
        var TheatreData = from allrec in da.Theatre_Tbls
                         select allrec;
        return TheatreData;
    }
    public static IEnumerable<Movie_Tbl> getSpecificMovie(int MovieID)
    {
        var da = getContext(); 
        var MovieData = from allrec in da.Movie_Tbls
                        where allrec.Status == "Active" && allrec.MovieID==MovieID
                        select allrec;
        return MovieData;
    }
    public static IEnumerable<Lgn_Tbl> getPassword(string email,string phoneno)
    {
        var da = getContext();
        var UserForgetPassword = from allrec in da.Lgn_Tbls
                        where allrec.UserEmail == email && allrec.PhoneNo == phoneno && allrec.Status=="Active"
                        select allrec;
        return UserForgetPassword;
    }
    public static IEnumerable<Lgn_Tbl> LoginUser(string email, string Password)
    {
        var da = getContext();
        var userLogin = from allrec in da.Lgn_Tbls
                                 where allrec.UserEmail == email && allrec.Password == Password && allrec.Status == "Active"
                                 select allrec;
        return userLogin;
    }
    public static IEnumerable<Lgn_Tbl> CheckExistingemail(string Email)
    {
        var da = getContext();
        var userEmail = from allrec in da.Lgn_Tbls
                        where allrec.UserEmail == Email && allrec.Status == "Active"
                        select allrec;
        return userEmail;
    }
    public static bool  AddUser(string userEmail, string Password, string Status, string userType, string Name, string PhoneNo)
    {
        bool isInserted = false;
        try
        {
            var da = getContext();
            Lgn_Tbl userDeatail = new Lgn_Tbl();
            userDeatail.Name = Name;
            userDeatail.Password = Password;
            userDeatail.PhoneNo = PhoneNo;
            userDeatail.Status = "Active";
            userDeatail.UserEmail = userEmail;
            userDeatail.UserType = userType;
            da.Lgn_Tbls.InsertOnSubmit(userDeatail);
            Wallet walet = new Wallet();
            walet.EmailID = userEmail;
            walet.Amount = 0;
            da.SubmitChanges();
            isInserted = true;
        }
        catch (Exception)
        {

            return isInserted;
        }

        return isInserted;
    }
    public static bool InsertMovie(string MovieName,string Description,string Director,string releasedate,string movieImg,string movieTrailer,string movieTyp,string cast,string story )
    {
        bool isInserted = false;
        try
        {
            var da = getContext();
            Movie_Tbl newMovie = new Movie_Tbl();
            
            newMovie.MovieImage = movieImg;
            newMovie.MovieName = MovieName;
            newMovie.MovieTrailer = movieTrailer;
            newMovie.Release_Date = releasedate;
            newMovie.Status = "Active";
            newMovie.Description = Description;
            newMovie.Director = Director;
            newMovie.MovieTyp = movieTyp;
            newMovie.Cast = cast;
            newMovie.Story = story;
            newMovie.Likes = 0;
            da.Movie_Tbls.InsertOnSubmit(newMovie);
            da.SubmitChanges();
            isInserted = true;
        }
        catch (Exception)
        {
            
           return isInserted;
        }

        return isInserted;
    }

    public static bool InsertTheatre(string theatreName, string Area, string Address)
    {
        bool isInserted = false;
        try
        {
            var da = getContext();
            Theatre_Tbl newTheatre = new Theatre_Tbl();
            newTheatre.ThatreName = theatreName;
            newTheatre.Area = Area;
            newTheatre.Address = Address;
            da.Theatre_Tbls.InsertOnSubmit(newTheatre);
            da.SubmitChanges();
            isInserted = true;
        }
        catch (Exception)
        {

            return isInserted;
        }

        return isInserted;
    }

    public static bool InsertShow(int currentmovie, int currenttheatre, string showtime,int noofseats)
    {
        bool isInserted = false;
        try
        {
            var da = getContext();
            Show_Tbl newTheatre = new Show_Tbl();
            newTheatre.CureentMovie = currentmovie;
            newTheatre.CurrentTheatre = currenttheatre;
            newTheatre.ShowTime = showtime;
            newTheatre.RemainingSeats = noofseats;
            da.Show_Tbls.InsertOnSubmit(newTheatre);
            da.SubmitChanges();
            isInserted = true;
        }
        catch (Exception)
        {
            return isInserted;
        }

        return isInserted;
    }

    public static bool ContactUSValue(string name, string Email, string phone, string subj, string mesg)
    {
        bool isInserted = false;
        try
        {
            var da = getContext();
            Contact_US newReq = new Contact_US();
            newReq.Email = Email;
            newReq.Message = mesg;
            newReq.PhoneNo = phone;
            newReq.Subject = subj;
            newReq.Name = name;
            da.Contact_US.InsertOnSubmit(newReq);
            da.SubmitChanges();
            isInserted = true;
        }
        catch (Exception)
        {

            return isInserted;
        }

        return isInserted;
    }

    public static IEnumerable<Theatre_Tbl> getTheatre(string thatrename)
    {
        var da = getContext();
        var userEmail = from allrec in da.Theatre_Tbls
                        select allrec;
        return userEmail;
    }

    public static IEnumerable<Movie_Tbl> getMovie(string Moviename)
    {
        var da = getContext();
        var userEmail = from allrec in da.Movie_Tbls
                        select allrec;
        return userEmail;
    }

    public static int getShow(int movieid,int theatreid,string showtime)
    {
        try
        {
            var da = getContext();
            var ShowData = from allrec in da.Show_Tbls
                           where allrec.CureentMovie == movieid && allrec.CurrentTheatre == theatreid && allrec.ShowTime == showtime
                           select allrec.ShowID;
            return ShowData.First();
        }
        catch (Exception ex)
        {

            return 0;
        }
    }
    public static IEnumerable<Show_Tbl> getShowSeats(int movieid, int theatreid, string showtime)
    {
        var da = getContext();
        var ShowData = from allrec in da.Show_Tbls
                       where allrec.CureentMovie == movieid && allrec.CurrentTheatre == theatreid && allrec.ShowTime == showtime
                       select allrec;
        return ShowData;
    }
    
    public static IEnumerable<Show_Tbl> getShowCollection(int movieid, int theatreid)
    {
        var da = getContext();
        var ShowData = from allrec in da.Show_Tbls
                       where allrec.CureentMovie == movieid && allrec.CurrentTheatre == theatreid
                       select allrec;
        return ShowData;
    }

    public static int getBookingCollection(int ShowID)
    {
        int seat = 0;
         var da = getContext();
         try
         {
             var ShowData = from allrec in da.Book_Tickets
                            where allrec.ShowID == Convert.ToString(ShowID)
                            select allrec.Bookin_ID;
             return ShowData.First();
         }
          catch(Exception ex)
         {
             seat = 0;
         }
         finally
         {
             
         }
         return seat;

    }
    public static List<int> getSeatsCollection(string bookingID)
    {
        var da=getContext();
        var seatcoll = from allrec in da.Seat_Tbls
                       where allrec.Booking_ID == bookingID
                       select allrec;
        List<int> seatlist = new List<int>();
        try
        {
            if (seatcoll.Count() > 0)
            {
                foreach (var item in seatcoll)
                {
                    seatlist.Add(Convert.ToInt32(item.Seat_No));
                }
            }
        }
        catch (Exception)
        {
            
            
        }
        return seatlist;

    }



  
    public static void BookTicket(string ShowID, string transactionID, string userMail, string currentDate, string ticketDate, string bookedStatus, string[] SeatArr)
    {
        var da = getContext();
        Book_Ticket bookticket = new Book_Ticket();
        bookticket.ShowID = ShowID;

        bookticket.Status = "Booked";
        bookticket.Movie_Date = ticketDate;
        bookticket.TransactionID = transactionID;
        bookticket.UserEmail = userMail;
        bookticket.Booking_Date = currentDate;
        da.Book_Tickets.InsertOnSubmit(bookticket);
        da.SubmitChanges();

        foreach (string item in SeatArr)
        {
            Seat_Tbl seat = new Seat_Tbl();
            seat.Seat_No = item;
            seat.Status = "Booked";
            seat.Booking_ID = Convert.ToString(bookticket.Bookin_ID);
            da.Seat_Tbls.InsertOnSubmit(seat);
        }
       
        da.SubmitChanges();
        

    }

    public static IEnumerable<Wallet> getWalletAmount(string email)
    {
        var da=getContext();
        var Amount = from allrec in da.Wallets
                     where allrec.EmailID == email
                     select allrec;
        return Amount;
    }
    public static void UpdateWallet(string Email,int amount)
    {
        var da = getContext();
        //Wallet wallet = getWalletAmount(Email).Single(walet => walet.EmailID == Email);
        Wallet wallet = da.Wallets.Single(walet => walet.EmailID == Email);
        wallet.Amount = amount;
        da.SubmitChanges();
      
    }
    public static bool CancelTicket(int BookingID)
    {
        bool IsTicketCanceled = false;
        try
        {
            var da = getContext();
            int Amount = 0;
            Book_Ticket ticket = da.Book_Tickets.Single(booking => booking.Bookin_ID == BookingID);
            ticket.Status = "Canceled";
            da.SubmitChanges();
            Transaction_Tbl transaction = da.Transaction_Tbls.Single(trans => trans.TransactionID == ticket.TransactionID);
            Amount = Convert.ToInt32(transaction.Amount);
            double RefundAmount = Amount * .50;
            transaction.Status = "Refunded";
            da.SubmitChanges();
            UpdateWallet(ticket.UserEmail, Convert.ToInt32(RefundAmount));
            Refund_Tbl refund = new Refund_Tbl();
            refund.TransactionID = transaction.TransactionID;
            refund.RefundAmount = Convert.ToInt32(RefundAmount);
            refund.Status = "Success";
            refund.RefundDate = System.DateTime.Now.ToLongDateString();
            da.Refund_Tbls.InsertOnSubmit(refund);
            da.SubmitChanges();
            var seattblcoll = from allrec in da.Seat_Tbls
                              where allrec.Booking_ID == Convert.ToString(ticket.Bookin_ID)
                              select allrec;
            foreach (var item in seattblcoll)
            {
                item.Status = "Offered";
                da.SubmitChanges();
            }
            da.SubmitChanges();
            IsTicketCanceled = true;
        }
        catch (Exception ex)
        {
            
           
        }
        return IsTicketCanceled;
    }

    public static IEnumerable<Book_Ticket> CheckExistingTransaction(string transactionID)
    {
        var da = getContext();
        var existingtransaction = from allrec in da.Book_Tickets
                                  where allrec.TransactionID == transactionID
                                  select allrec;
        return existingtransaction;
    }

    public static DataTable getShow(string showid)
    {
        var da=getContext();
        DataTable dt = new DataTable();
        dt.Columns.Add("Moviename");
     
        dt.Columns.Add("TheatreName");
     
        dt.Columns.Add("SelectedDate");
        dt.Columns.Add("selectTotalSeats");
        DataRow dr = dt.NewRow();
        var getShow = from allrec in da.Show_Tbls
                      where allrec.ShowID ==Convert.ToInt32(showid)
                      select allrec;
        foreach (var item in getShow)
        {
            var theatrename = ConnectionClass.getTheatreByID(Convert.ToInt32(item.CurrentTheatre));
            var moviename = ConnectionClass.getMovieByID(Convert.ToInt32(item.CureentMovie));
            dr["Moviename"] = moviename;
            dr["TheatreName"] = theatrename;
            dt.Rows.Add(dr);
           
        }

        return dt;
    }

    private static string getTheatreByID(int p)
    {
         var da=getContext();
         var theatren = from allrec in da.Theatre_Tbls
                        where allrec.ThatreID == p
                        select allrec.ThatreName;
         return theatren.First();
             
    }
    private static string getMovieByID(int p)
    {
        var da = getContext();
        var movied = from allrec in da.Movie_Tbls
                       where allrec.MovieID == p
                       select allrec.MovieName;
        return movied.First();

    }

    public static void AddWalet(string Emailid, int p)
    {
        var da = getContext();
        Wallet walet = new Wallet();
        walet.EmailID = Emailid;
        walet.Amount = p;
        da.Wallets.InsertOnSubmit(walet);
        da.SubmitChanges();
    }
    public static void InsertTransaction(string Emailid, string Amount,string status,string tansactionID)
    {
        var da = getContext();
        Transaction_Tbl trans = new Transaction_Tbl();
        trans.EmailID = Emailid;
        trans.Amount = Amount;
        trans.Status = status;
        trans.TransactionID = tansactionID;
        da.Transaction_Tbls.InsertOnSubmit(trans);
        da.SubmitChanges();
    }

    public static IEnumerable<Book_Ticket> getBookingData(string userMail)
    {
        var da = getContext();
        var BookTicketCollection = from allrec in da.Book_Tickets
                                   where allrec.UserEmail == userMail
                                   select allrec;
        return BookTicketCollection;
        
    }

    public static DataTable GenerateTicket(int BookingID)
    {
        DataTable dt = new DataTable();
        try
        {
            var da = getContext();
            Book_Ticket tckt = da.Book_Tickets.Single(ticket => ticket.Bookin_ID == BookingID);
            Show_Tbl show = da.Show_Tbls.Single(shw => shw.ShowID == Convert.ToInt32(tckt.ShowID));
            List<int> seatList = getSeatsCollection(Convert.ToString(BookingID));
            Theatre_Tbl theatr = da.Theatre_Tbls.Single(thtr => thtr.ThatreID == show.CurrentTheatre);
            Movie_Tbl muvie = da.Movie_Tbls.Single(mv => mv.MovieID == show.CureentMovie);
            
            
            dt.Columns.Add("TicketNo");
            dt.Columns.Add("ShowID");
            dt.Columns.Add("TheatreName");
            dt.Columns.Add("MovieName");
            dt.Columns.Add("SeatNo",typeof(List<int>));
            dt.Columns.Add("MovieDate");
            dt.Columns.Add("BookingDate");
            dt.Columns.Add("Bookedstatus");
           
            DataRow dr = dt.NewRow();
            dr["TicketNo"] = tckt.Bookin_ID;
            dr["ShowID"] = show.ShowID;
            dr["SeatNo"] = seatList;
            dr["MovieName"] = muvie.MovieName;
            dr["MovieDate"] = tckt.Movie_Date;
            dr["TheatreName"] = theatr.ThatreName;
            dr["BookingDate"] = tckt.Booking_Date;
            dr["Bookedstatus"] = tckt.Status;
            dt.Rows.Add(dr);
            return dt;
        }
        catch (Exception)
        {
            
          
        }
        return dt;

    }


    public static DataTable GetOfferedData()
    {
        DataTable dt = new DataTable();
        try
        {
            var da = getContext();
            var offrtckts = da.Seat_Tbls.Where(seat => seat.Status == "Offered");
           
            dt.Columns.Add("ShowID");
            dt.Columns.Add("TheatreName");
            dt.Columns.Add("MovieName");
            dt.Columns.Add("SeatNo");
            dt.Columns.Add("MovieDate");
            dt.Columns.Add("Bookedstatus");
            dt.Columns.Add("Book");
            string list=null;
            Dictionary<string, string> seatdict = new Dictionary<string,string>();
            foreach (Seat_Tbl item in offrtckts)
            {
                if(seatdict.ContainsKey(item.Booking_ID))
                {
                    list = seatdict[item.Booking_ID];
                    list+=","+item.Seat_No;
                    seatdict[item.Booking_ID] = list;
                }
                else
                {
                    list+=item.Seat_No;
                    seatdict[item.Booking_ID] = list;  
                }
            }

            foreach (Seat_Tbl item in offrtckts)
            {
                Book_Ticket booktckt = da.Book_Tickets.Single(tckt => tckt.Bookin_ID == Convert.ToInt32(item.Booking_ID));
                Show_Tbl show = da.Show_Tbls.Single(shw => shw.ShowID == Convert.ToInt32(booktckt.ShowID));
                Theatre_Tbl theatr = da.Theatre_Tbls.Single(thtr => thtr.ThatreID == show.CurrentTheatre);
                Movie_Tbl muvie = da.Movie_Tbls.Single(mv => mv.MovieID == show.CureentMovie);
                DataRow dr = dt.NewRow();
                dr["ShowID"] = show.ShowID;
                dr["SeatNo"] = seatdict[item.Booking_ID];
                dr["MovieName"] = muvie.MovieName;
                dr["MovieDate"] = booktckt.Movie_Date;
                dr["TheatreName"] = theatr.ThatreName;
                dr["Bookedstatus"] = item.Status;
                dr["Book"] = "";
                dt.Rows.Add(dr);

            }
            return dt;
        }
        catch (Exception)
        {

            
        }
        return dt;
    }

    public static IEnumerable<Book_Ticket> GetBookingIDData(string ShowID)
    {
        var da = getContext();
        var id = from allrec in da.Book_Tickets
                 where allrec.ShowID == ShowID && allrec.Status == "Offered"
                 select allrec;
        return id;
    }

   
    public static void UpdatePassword(string Email, string p)
    {
        var da = getContext();
        Lgn_Tbl UserRecord = da.Lgn_Tbls.Single(lgnuser => lgnuser.UserEmail == Email);
        UserRecord.Password = p;
        da.SubmitChanges();
    }

    public static bool IsUserRated(string userEmail, string MovieId)
    {
        var da=getContext();
        var ratedData = from allrec in da.Movie_Ratings
                        where allrec.UserEmail == userEmail && allrec.MovieID == Convert.ToInt32(MovieId)
                        select allrec;
        return ratedData.Any();
    }
    public static int UserCount( string MovieId)
    {
        var da = getContext();
        var ratedData = from allrec in da.Movie_Ratings
                        where allrec.MovieID == Convert.ToInt32(MovieId)
                        select allrec;
        return ratedData.Count();
    }
    public static IEnumerable<Rating> GetMovieRating(string MovieId)
    {
        var da = getContext();
        var ratedData = from allrec in da.Ratings
                        where allrec.MovieId == Convert.ToInt32(MovieId)
                        select allrec;
        return ratedData;
    }

    public static void UpdateRating(int MovieId ,string rating)
    {
        var da = getContext();
        Rating movierating = da.Ratings.Single(movi => movi.MovieId == MovieId);
        movierating.Rating1 =Convert.ToInt32(Convert.ToInt32(movierating.Rating1) + Convert.ToInt32(rating));
        da.SubmitChanges();
    }
    public static void RateMovie(string userEmail, string ratng, string MovieId)
    {
        var da = getContext();
        Movie_Rating rating = new Movie_Rating();
        rating.Rating = ratng;
        rating.UserEmail = userEmail;
        rating.MovieID =Convert.ToInt32(MovieId);
        da.Movie_Ratings.InsertOnSubmit(rating);
        da.SubmitChanges(); 
    }
    public static void AddRating(string ratng, string MovieId)
    {
        var da = getContext();
        Rating rtng = new Rating();
        rtng.MovieId = Convert.ToInt32(MovieId);
        rtng.Rating1 = Convert.ToInt32(ratng);
        da.Ratings.InsertOnSubmit(rtng);
        da.SubmitChanges();
    }
}
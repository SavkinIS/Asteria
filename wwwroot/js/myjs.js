$(document).ready(function () {
    let today = 0;    
    let booking_day  = "";
    let booking_month = new Date().getMonth();
    let booking_date = new Date();
    let gender= "all";
    let typeWorck = "all";

    $(".conteiner").hover(function(){
 
     $(this).children('.sec').css("color", "black");
      });

    $(".conteiner").mouseleave(function(){
 
    $(this).children('.sec').css("color", "#bca858");
     });  
     
     


     
    $(".contact_box").hover(function(){
        $(this).children().css("color", "#bca858");
    }) ;
    $(".contact_box").mouseleave(function(){
        $(this).children().css("color", "silver");
    }) ;

    
    $(".bt_type_spec, .bt_type_work").click(function(){
        $(this).parent().children().css("background-color", "unset");
        $(this).css("background-color", "#bca858");
    });

    //изменене света календаря
    
    $(".calendar__number").click(function(){
        $(this).parent().children().removeClass("selected_day");
        $(this).addClass("selected_day");
        booking_date.setDate($(this).text());
        booking_day = $(this).text();
        booking_month =new Date().getMonth()+today +1;
        
        
    });
    
    var tx= $('.today_num').text();
    var elements = $(".calendar__number").filter(function() {
    return $(this).text() === tx;
    }).css('border', '1px solid red');

   //перелистывание календаря

    $(".right_bt").click(function(){
        
        today++;
        booking_month = booking_month+1;
        booking_date.setMonth(booking_month);
        

        if(today!=0){
            elements.css('border', '1px solid #fff');
        }
        else{
            elements.css('border', '1px solid red')
        }
    });
    $(".left_bt").click(function(){
        today = today-1;
        booking_month = booking_month-1;
        booking_date.setMonth(booking_month);
       ;

        if(today!=0){
            elements.css('border', '1px solid #fff');
        }
        else{
            elements.css('border', '1px solid red');
        }
    });


    

    //Получаем для кого будет оказана услуга
    gender= "all";
    $(".bt_type_spec").click(function(){
        gender = $(this).attr( "title" );

        console.log(gender);
    });

    //получим тип оказания услуги
    typeWorck = "all";
    $(".bt_type_work").click(function(){
        typeWorck =$(this).attr( "title" );
        console.log(typeWorck);
    });

/*
   let month=new Array("01","02","03","04","05","06",
                    "07","08","09","10","11","12")
    let t = new Date();
    let data =(t.getFullYear()+"-"+month[t.getMonth()]+"-"+t.getDate());
    $('input[name=date]').val(data);*/
   // $("#data_input").val(data);


    //открытие расписания 
   /* $(".one_spec").click(function(){
        let timeT = $(this).parent();
        for (let index = 9; index < 20; index++) {
           for (let i = 00; i < 60; i+15) {
            $(this).parent().children("timetable").append(`
            <div class = "time_of_day"><p>${index}:${i}</p></div> 
            `);
           }
            
        }
    });*/



    $(".one_spec").click(function(){
        $("#one_form").remove();
        $(".time_of_day").remove();
        let timeT = $(this).parent();
        for (let index = 9; index < 20; index++) {
           for (let i = 00; i < 60; i++) {
             let z = "";
             
             if(i=== 0){
               z="0";
               
             }
             
            $(this).parent().children(".free_time").append(`
            <div class = "time_of_day"><p>${index}:${i+z}</p></div> 
            
            `);
           /* $('.time_of_day').text(function(){
               if($(this).text() === "10:30"){
               $(this).hide();
               
             }});*/
                                    
             i = i+14;
             
             ; }}
        
        $(this).parent().children(".timetable").append(`
        <form class="contact_form" action="https://echo.htmlacademy.ru/"  method="#" id = "one_form" name="contact_form">
                    <ul>
                    
                        <li>
                             <h2>Запись на прием</h2>
                             <span class="required_notification">* Не отмеченные поля</span>
                        </li>
                        <li>
                        <label for="spec">Имя:</label>
                        <input type="text"  placeholder="Алла"  name = "spec" required />
                    </li>
                        <li>
                            <label for="name">Имя:</label>
                            <input type="text"  placeholder="Алла"  name = "name" required />
                        </li>
                        <li>
                            <label for="phone">Phone:</label>
                            <input type="tel" name="phone"                                placeholder="+7 926 982-77-52"  
                                   pattern="+79[0-9]{2}[0-9]{3}[0-9]{2}[0-9]{2}"
                       required>
                            <span class="form_hint">+7 926 982-77-52"</span>
                        </li>
                        <li>
                           <label for="data">Дата приема:</label>
                            <input type="date"  name = "date" id= "data_input"   required />
                        </li>
                        <li>
                           <label for="time">Желаемое время приема:</label>
                            <input type="time"  name = "time" id= "time_input"  required />
                        </li>
                        
                        <li>
                        <label for="wk_selectone">Выберите услугу:</label>
                                <select id="type_wk_select" name="wk_select">
                                    <option value="face" >Макияж</option>
                                    <option value="haircut">Стрижка</option>
                                    <option value="painHair" >Окрашивание</option>
                                    <option value="manicure">Маникюр</option>
                                  <option value="pedicure"  >Педикюр</option>
                                  <option value="massage">Массаж</option>
                                  <option value="all">Не определились</option>
                                </select>
                        
                          </li>
                        <li>
                            <label for="message">Message:</label>
                            <textarea name="message" id= "mes"          cols="40" rows="6" ></textarea>
                        </li>
                        
                        
                        <li>
                      </br>
                            <button class="submit" type="submit">Submit Form</button>
                        </li>
                    </ul>
                </form>
        `);
      

    let specName = $(this).children(".spec_desc").children(".spec_name").text();
    
    $('input[name=spec]').val(specName);
    $('input[name=spec]').attr('disabled', 'disabled');

    let month=new Array("01","02","03","04","05","06",
    "07","08","09","10","11","12")
    let t = new Date();
    let data =(booking_date.getFullYear()+"-"+month[booking_date.getMonth()]+"-"+booking_date.getDate());

    $('input[name=date]').val(data);
    $('select[name=wk_select]').val(typeWorck);
    $("#type_wk_select option[value= typeWorck ]").attr("selected", "selected");


    $(".time_of_day").click(function(){
        $(".time_of_day").removeClass("reserved");
        $(this).addClass("reserved");
        let tm = $(this).text();
        $("#time_input").val(tm);
        
    });
    
       
    });

   

});


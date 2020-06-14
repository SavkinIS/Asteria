$(document).ready(function () {
    var dataLL =  new Array();
    var trRow = "";
    $("#menu2nd").hide();
    $("#p-alert").hide();
   $("#change").hide();
   $("#table-chg").hide();
   $("#th-hide").hide();
    let i_sheets = 0;
    let id = 0;


    //раскрыть выбор таблицы с заказами на день
    $("#sheets-bt").click(function () {

        if (i_sheets == 0) {
            $("#menu2nd").fadeIn();
            i_sheets++;
        }
        else {
            $("#menu2nd").fadeOut();
            i_sheets--;
        }

    });

    //выборка таблицы
    $("#sheets_take").click(function () {
        $("#p-alert").hide();
        $("#table").empty();
      

        if ($("#bt").contents().text() === "Выберите специалиста" || $("#bt").contents().text() === "Все") {

            if ($('input[name=date-main]').val() === "") {
                $("#p-alert").show();
            }
            else {
                dataLL =  loadAll();
               
            }
            
        }
        else {
            if ($('input[name=date-main]').val() === "") {
                $("#p-alert").show();
            } else {
                dataLL = load();
                
            }
            
        }
        
      
    });

        

    //Поиск айди записи
    $("#table").on("click",'.row-select',function( event ) {       
        $("#change").fadeOut();
        $("#table-chg").fadeOut();
        $(".row-select").css("background", "#fff");
       $(this).css("background", "#17a2b817");
       var $td = $(this);
       id =  $(this).parent().children().index($(this));
        
      //  alert(id);
        $("#change").fadeIn();

    });


//изменение записи
    $("#change").click(function(){
        $("#table-chg").fadeIn();

      let str = dataLL.value[id].date.toString().substr(0,10);

      
      
      $('input[name=date]').val(str);
      $('input[name=id]').val(dataLL.value[id].id);
      var spec = dataLL.value[id].specName;
      $('#chgSpec').val(spec);
        
      $('input[name=time]').val(dataLL.value[id].time.toString().substr(0,5));

      $('input[name=clientName]').val(dataLL.value[id].clientName);
      $('input[name=typeWork]').val(dataLL.value[id].typeWork);
      $('input[name=price]').val(dataLL.value[id].price);
      $('input[name=clientid]').val(dataLL.value[id].clientid);
      $('input[name=specId]').val(dataLL.value[id].specId);
      $("#th-hide").css("display", "none");
        
    

    });

});

function load() {
        let dataL = new Array();
        let date = $('input[name=date-main]').val();
        let spec = $("#bt").contents().text();
        if (date === "") {
            $("#p-alert").show();
        } else {
            $.ajax({
                url:  "/Home/GetRecords",
                async: false,
                data: {
                    date: date,
                    spec: spec
                },
                success: function (rezult) {
                    dataL = rezult;

                    
                    let x = dataL.value.length;
                    $("#table").append(`
                              
                    <thead>
                        <tr>
                            <th scope="col">Id</th>
                            <th scope="col">Дата</th>
                            <th scope="col">Время</th>
                            <th scope="col">Имя клиента</th>
                            <th scope="col">Вид услуги</th>
                            <th scope="col">Цена</th>

                        </tr>
                    </thead>
                <tbody id= "tb"> </tbody>`);
                    for (let i = 0; i < x; i++) {
                        $("#tb").append(`

                            <tr class="row-select"   >
                            <th class = "idRec" scope="col">${dataL.value[i].id}</th>                            
                            <th scope="col">${dataL.value[i].date.substr(0,10)}</th>
                            <th   scope="col">${dataL.value[i].time.substr(0,5)}</th>
                            <th   scope="col">${dataL.value[i].clientName}</th>
                            <th  scope="col">${dataL.value[i].typeWork}</th>
                            <th   scope="col">${dataL.value[i].price}</th>
                            
                            </tr> `);
                    }
                    
                }
            });
        
        }
        return dataL;
        console.log("Loaded");
}


function loadAll() {
    let dataL =  new Array();
    let date = $('input[name=date-main]').val();
    let spec = $("#bt").contents().text();
    if (date === "") {
        $("#p-alert").show();
    } else {
        $.ajax({
            url: "/Home/GetRecordsData",
            async: false,
            data: {
                date: date,
               
            },
            success: function (rezult) {
                dataL = rezult;
                let x = dataL.value.length;
                $("#table").append(`
                              
                    <thead>
                        <tr>
                            <th scope="col">Id</th>
                            <th scope="col">Специалист</th>
                            <th class = "trDate" scope="col">Дата</th>
                            <th scope="col">Время</th>
                            <th scope="col">Имя клиента</th>
                            <th scope="col">Вид услуги</th>
                            <th scope="col">Цена</th>

                        </tr>
                    </thead>
                <tbody id= "tb"> </tbody>`);
                for (let i = 0; i < x; i++) {
                    $("#tb").append(`

                            <tr class="row-select">
                            <th class = "idRec"  scope="col">${dataL.value[i].id}</th>
                            <th  scope="col">${dataL.value[i].specName}</th>
                            <th  scope="col">${dataL.value[i].date.substr(0,10)}</th>
                            <th  scope="col">${dataL.value[i].time.substr(0,5)}</th>
                            <th  scope="col">${dataL.value[i].clientName}</th>
                            <th  scope="col">${dataL.value[i].typeWork}</th>
                            <th  scope="col">${dataL.value[i].price}</th>

                            </tr> `);
                }
              
            }
        });

    }
    return dataL;
    console.log("Loaded");
}





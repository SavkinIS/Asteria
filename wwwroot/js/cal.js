'use strict';
var path = document.getElementById('cldr');
var date = new Date();
var now_month = date.getMonth();
var now_day = date.getDate();
var date1 = new Date(date.getFullYear(), now_month, 1);
var date2 = new Date(date.getFullYear(), now_month + 1, 1);
/*Количество дней в месяце*/

var max_days = Math.round((date2 - date1) / 1000 / 3600 / 24); //alert(date1);

date.setDate(1); //Позицая первого дная месяце всреди дней недели

var fst_day_of_week = date1.getDay() - 2;
date = new Date();
//alert(fst_day_of_week);
var days = []; //отступ до первого числа от понедельника

for (let z = 0; z < fst_day_of_week + 1; z++) {
  days.push("");
} //заполнение днями


for (let z = 1; z < max_days + 2; z++) {
  let x = z - 1;

  if (x > 0) {
    days.push(x);
  }
}

var months = new Array("Января", "Февраля", "Марта", "Апреля", "Мая", "Июня", "Июля", "Августа", "Сентября", "Октября", "Ноября", "Декабря");
var day_of_w = new Array("Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс");
var all_days = [40];
/*alert(all_days.length);*/

class NameForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      value: '',
      isLoggedIn: false,
      arrDays: days,
      today: now_day,
      dataText: " " + months[now_month]
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({
      value: event.target.value
    });
  }

  handleSubmit(event) {
    alert('A name was submitted: ' + this.state.value);
    event.preventDefault();
  }

  plusMonth() {
    if (now_month >= 11) {
      now_month = -1;
    }

    var newM = now_month + 1;
    date1 = new Date(date.getFullYear(), newM, 1);
    date2 = new Date(date.getFullYear(), newM + 1, 1);
    /*Количество дней в месяце*/

    max_days = Math.round((date2 - date1) / 1000 / 3600 / 24); //alert(date1);

    date.setDate(1); //Позицая первого дная месяце всреди дней недели

    var fst_day_of_week = date1.getDay() - 2;
    date = new Date(); //alert(fst_day_of_week);

    var days_new = []; //отступ до первого числа от понедельника

    for (let z = 0; z < fst_day_of_week + 1; z++) {
      days_new.push("");
    } //заполнение днями


    for (let z = 1; z < max_days + 2; z++) {
      let x = z - 1;

      if (x > 0) {
        days_new.push(x);
      }
    }

    days = days_new;
    now_month = newM;
    this.setState({
      isLoggedIn: true,
      arrDays: days,
      dataText: " " + months[newM]
    });
  }

  minusMonth() {
    if (now_month <= 0) {
      now_month = 12;
    }

    var newM = now_month - 1;
    date1 = new Date(date.getFullYear(), newM, 1);
    date2 = new Date(date.getFullYear(), newM + 1, 1);
    /*Количество дней в месяце*/

    max_days = Math.round((date2 - date1) / 1000 / 3600 / 24); //alert(date1);

    date.setDate(1); //Позицая первого дная месяце всреди дней недели

    var fst_day_of_week = date1.getDay() - 2;
    date = new Date(); //alert(fst_day_of_week);

    var days_new = []; //отступ до первого числа от понедельника

    for (let z = 0; z < fst_day_of_week + 1; z++) {
      days_new.push("");
    } //заполнение днями


    for (let z = 1; z < max_days + 2; z++) {
      let x = z - 1;

      if (x > 0) {
        days_new.push(x);
      }
    }

    days = days_new;
    now_month = newM;
    this.setState({
      isLoggedIn: true,
      arrDays: days,
      dataText: " " + months[newM]
    });
  }

  render() {
    var text = "";

    if (this.state.value != '') {
      text = 'На ' + this.state.value + " записей нет";
    }

    ;
    var i = 30;
    var index = 1;
    var curent = '';
    return /*#__PURE__*/React.createElement("div", {
      className: "calendar"
    }, /*#__PURE__*/React.createElement("div", {
      className: "calendar__picture"
    }, /*#__PURE__*/React.createElement("div", {
      className: "left_bt",
      onClick: () => this.minusMonth()
    }), /*#__PURE__*/React.createElement("h2", null, /*#__PURE__*/React.createElement("b", {
      className: "today_num"
    }, this.state.today), this.state.dataText), /*#__PURE__*/React.createElement("div", {
      className: "right_bt",
      onClick: () => this.plusMonth()
    })), /*#__PURE__*/React.createElement("div", {
      className: "calendar__date"
    }, day_of_w.map(day => /*#__PURE__*/React.createElement("div", {
      className: "calendar__day"
    }, day)), this.state.arrDays.map(day => /*#__PURE__*/React.createElement("div", {
      className: "calendar__number"
    }, day))));
  }

}

ReactDOM.render( /*#__PURE__*/React.createElement(NameForm, null), path);
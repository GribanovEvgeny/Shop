let items;

$(document).ready(function () {
	$('#cart').addClass('hidden');
	FillFromSession();

	if (document.cookie.match("country") == undefined)  // проверяем, есть ли куки
		OpenPopup(); // если нет, то показываем попап
	else
		$('#country').html(document.cookie.valueOf('country').replace('country=', ''));   // иначе подгружаем город для вывода на страницу
});

function FillFromSession() {
	items = JSON.parse(sessionStorage.getItem("productsInCart"));
	if (items.length > 0) {
		let summa = 0;
		let list = $('#inCart');
		list.empty();    // очищаем список на сайте
		for (i in items) {
			list.append(`
        <li id="item${items[i].id}">
            <div class="inCart_name">${items[i].productName}</div>
            <div class="inCart_right">
                <div class="inCart_price">Цена: ${items[i].productPrice} руб</div>
                <div class="inCart_rightrow">
                    <div class="inCart_minus" onclick="UpdateResult(${items[i].productPrice}, false, 'count${items[i].id}')">–</div>
                    <div class="inCart_count" id="count${items[i].id}">${items[i].countProduct}</div>
                    <div class="inCart_plus" onclick="UpdateResult(${items[i].productPrice}, true, 'count${items[i].id}')">+</div>
                </div>
            </div>
        </li>`);
			summa += items[i].productPrice * items[i].countProduct;
		}
		$('#resultInCart').html('ИТОГО: ' + summa);
		$('#postList').removeClass('hidden');
	}
}

function UpdateResult(price, plus, itemId) {
	let id = itemId.substr(5);
	if (plus) {
		let newPrice = Number($('#resultInCart').html().substr(7)) + price;
		$('#resultInCart').html('ИТОГО: ' + newPrice);
		$('#' + itemId).html(+$('#' + itemId).html() + 1);

		for (i in items) {
			if (items[i].id == id)
				items[i].countProduct += 1;
		}
	}
	else {
		let newPrice = Number($('#resultInCart').html().substr(7)) - price;
		$('#resultInCart').html('ИТОГО: ' + newPrice);
		if (+$('#' + itemId).html() - 1 == 0) {
			$('#item' + id).remove();
			if (newPrice == 0)
				$('#postList').addClass('hidden');
		}
		else {
			$('#' + itemId).html(+$('#' + itemId).html() - 1);
		}

		for (i in items) {
			if (items[i].id == id) {
				if (items[i].countProduct == 1)
					items.splice(i, 1);
				else
					items[i].countProduct -= 1;
			}
		}
	}
	sessionStorage.setItem("productsInCart", JSON.stringify(items))
	$.ajax({
		url: "/Home/UpdateCartItems?cartItemId=" + id + "&plus=" + plus,
		success: function (data) {

		},
		cache: false
	});
}

function CreateOrder() {
	let countryName = document.cookie.valueOf('country').replace('country=', '');
	let cartItemJson = sessionStorage.getItem("productsInCart");
	$.ajax({
		url: "/Home/CreateOrder?cartItemJson=" + cartItemJson + "&countryName=" + countryName,
		success: function (data) {
			alert("Добавлен заказ с id=" + data);
		},
		cache: false
	});
}

function SetCountry(countryName) { // занести выбранную страну в куки
	document.cookie = `country=${countryName}; path=/;`;   // заносим значение в куки
	$('#country').html(countryName);    // меняем город на странице
	ClosePopup();
}

function OpenPopup() {  // открыть попап
	//document.querySelector('#popupCountry').classList.remove("hidden");
	$('#popupCountry').removeClass("hidden");
}

function ClosePopup() { // закрыть попап
	document.querySelector('#popupCountry').classList.add("hidden");    // спрятать попап
	if (document.cookie.match("country") == undefined) {    // если город не был выбран, хардкодим москву
		document.cookie = `country=Москва`;
		$('#country').html("Москва");
	}
}
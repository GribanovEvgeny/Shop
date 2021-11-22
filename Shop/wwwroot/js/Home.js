$(document).ready(function () {
	SortAndFilter();

	if (document.cookie.match("country") == undefined)  // проверяем, есть ли куки
		OpenPopup(); // если нет, то показываем попап
	else
		$('#country').html(document.cookie.valueOf('country').replace('country=', ''));   // иначе подгружаем город для вывода на страницу
0
	if (sessionStorage.getItem("productsInCart") != null) {  // если страницу перезагружают, то проверяем, есть ли сессия
		let items = JSON.parse(sessionStorage.getItem("productsInCart"));
		let countItems = CalcItemsCart(items)
		if (countItems > 0) {
			$('#cartCount p').text(countItems);
			$('#cartCount').removeClass('hidden');
		}
	}
});

function SortAndFilter() {
	$.ajax({
		url: "/Home/SortAndFilter?methodSort=" + $('#comboSort').val() + "&categoryId=" + $('#comboFilter').val(),
		success: function (data) {
			RefreshList(data);
		},
		cache: false
	});
}

function RefreshList(newList) { // обновление списка на странице
	let list = $('#ListProducts');
	list.empty();

	newList.forEach(function (product, i, newList) {
		list.append(`
				<li>
					<img src="${product.imageSrc}" alt="${product.name}">
					<h5>${product.name}</h5>
					<p>${product.description}</p>
					<button class="buttonBuy" onclick="PutInCart(${product.id})">${product.price} руб</button>
				</li>`)
	});
}

function SetCountry(countryName) { // занести выбранную страну в куки
	document.cookie = `country=${countryName}`;   // заносим значение в куки
	$('#country').html(countryName);    // меняем город на странице
	ClosePopup();
}

function OpenPopup() {  // открыть попап
	document.querySelector('#popupCountry').classList.remove("hidden");
}

function ClosePopup() { // закрыть попап
	document.querySelector('#popupCountry').classList.add("hidden");    // спрятать попап
	if (document.cookie.match("country") == undefined) {    // если город не был выбран, хардкодим москву
		document.cookie = `country=Москва`;
		$('#country').html("Москва");
	}
}

function PutInCart(ProductId) { // занести продукт в корзину
	$.ajax({
		url: "/Home/PutInCart?productId=" + ProductId,
		success: function (data) {
			$('#cartCount p').text(CalcItemsCart(data));
			$('#cartCount').removeClass('hidden');
			sessionStorage.setItem("productsInCart", JSON.stringify(data))
		},
		cache: false
	});
}

function CalcItemsCart(items) { // посчитать количество продуктов в корзине
	let count = 0;
	for (i in items)
		count += items[i].countProduct;
	return count;
}

function OpenCart() {
	$.post({
		url: "/Home/OpenCart"
	});
}
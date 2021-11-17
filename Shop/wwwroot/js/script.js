$(document).ready(function () {
	SortAndFilter();
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

function RefreshList(newList) {
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

function PutInCart(ProductId) {
	$.ajax({
		url: "/Home/PutInCart?productId=" + ProductId,
		success: function (data) {
			let countCart = $('#basketCount');
			countCart.removeClass('hidden');
			let countCartP = $('#basketCount p');
			countCartP.text(data);
		},
		cache: false
	});
}
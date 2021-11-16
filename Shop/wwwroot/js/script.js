$(document).ready(function () {
	SortAndFilter();
});

function SortAndFilter() {
	let url = "/Home/SortAndFilter?methodSort=" + $('#comboSort').val() + "&categoryId=" + $('#comboFilter').val();
	$.ajax({
		url: url,
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
					<form>
						<img src="${product.imageSrc}" alt="${product.name}">
						<h5>${product.name}</h5>
						<p>${product.description}</p>
						<button class="buttonBuy">${product.price} руб</button>
					</form>
				</li>`)
	});
}
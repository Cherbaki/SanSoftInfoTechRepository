let LineItemsJSONIF = document.getElementById('LineItemsJSONIFId');

let InvoiceItemsTable = document.getElementById('InvoiceItemsTableId');

let ItemDescriptionIF = document.getElementById('ItemDescriptionIFId');
let ItemQuantityIF = document.getElementById('ItemQuantityIFId');
let ItemUnitPriceIF = document.getElementById('ItemUnitPriceIFId');

let ItemDescriptionSpan = document.getElementById('ItemDescriptionSpanId');
let ItemQuantitySpan = document.getElementById('ItemQuantitySpanIFId');
let ItemUnitPriceSpan = document.getElementById('ItemUnitPriceSpanIFId');


let AddItemButton = document.getElementById('AddItemButtonId');

let CreateInvoiceButton = document.getElementById('CreateInvoiceButtonId');

let items = [];

function ValidateItemInputFields() {
    let valid = true;

    //Validate items description(Validate the length)
    if (ItemDescriptionIF.value.length > 1000) {
        ItemDescriptionSpan.style.display = 'block';
        valid = false;
    }
    else 
        ItemDescriptionSpan.style.display = 'none';

    //Validate items Quantity(Check if it's an integer number or if it's populated at all)
    if (ItemQuantityIF.value == null || ItemQuantityIF.value == "") {
        ItemQuantitySpan.style.display = 'block';
    }
    else {
        ItemQuantitySpan.style.display = 'none';
    }
    if (!Number.isInteger(ItemQuantityIF.value)) {
        let intValue = parseInt(ItemQuantityIF.value);
        ItemQuantityIF.value = intValue;
    }


    //Validate items Unti Price(Check if it is specified)
    if (ItemUnitPriceIF.value == null || ItemUnitPriceIF.value == "") {
        ItemUnitPriceSpan.style.display = 'block';
    }
    else
        ItemUnitPriceSpan.style.display = 'none';


    return valid;
}
function ClearItemInputFileds() {
    ItemDescriptionIF.value = '';
    ItemQuantityIF.value = '';
    ItemUnitPriceIF.value = '';

    ItemDescriptionSpan.value = '';
    ItemQuantitySpan.value = '';
    ItemUnitPriceSpan.value = '';
}
//This function adds the item both in the collection and the table
function AddItem() {
    //Validate the input fields
    var valid = ValidateItemInputFields();
    if (!valid)
        return;

    //At this point Input Files are validated
    let newItemDescription = ItemDescriptionIF.value;
    let newItemQuantity = parseInt(ItemQuantityIF.value);
    let newItemUnitPrice = parseInt(ItemUnitPriceIF.value);
    let totalPrice = newItemQuantity * newItemUnitPrice;

    //Create and add the items in the collection
    var newItem = {
        Description: newItemDescription,
        Quantity: newItemQuantity,
        UnitPrice: newItemUnitPrice,
        TotalPrice: totalPrice
    };
    items.push(newItem);

    //Create and add the item in the table
    let newItemQuantityTd = document.createElement('td');
    newItemQuantityTd.innerHTML = newItemQuantity;
    let newItemUnitPriceTd = document.createElement('td');
    newItemUnitPriceTd.innerHTML = newItemUnitPrice;
    let newItemTotalPriceTd = document.createElement('td');
    newItemTotalPriceTd.innerHTML = totalPrice;

    //Bind the td to a new row in a table
    let newItemRow = document.createElement('tr');

    newItemRow.appendChild(newItemQuantityTd);
    newItemRow.appendChild(newItemUnitPriceTd);
    newItemRow.appendChild(newItemTotalPriceTd);

    //Add the row to the table
    InvoiceItemsTable.appendChild(newItemRow);


    ClearItemInputFileds();
}


ItemDescriptionIF.addEventListener('change', () => {
    ValidateItemInputFields();
});
ItemQuantityIF.addEventListener('change', () => {
    ValidateItemInputFields();
});
ItemUnitPriceIF.addEventListener('change', () => {
    ValidateItemInputFields();
});

AddItemButton.addEventListener('click', () => {
    AddItem();
});
CreateInvoiceButton.addEventListener('click', () => {

    let InvoiceItemsSpan = document.getElementById('InvoiceItemsSpanId');
    //Validate if the items are created
    if (items.length <= 0) {
        InvoiceItemsSpan.style.display = 'block';
        return;
    }
    else
        InvoiceItemsSpan.style.display = 'none';

    LineItemsJSONIF.value = JSON.stringify(items);

    let SubmitForm = document.getElementById('SubmitFormId');
    SubmitForm.click();
        
});
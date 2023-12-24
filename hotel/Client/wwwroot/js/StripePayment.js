redirectToCheckout = function(sessionId) {
    var stripe = Stripe('pk_test_51OPojxFvPhzJoAdd35dIBtispyagB3NCcaSepVYdfXHvUjuBw14Uqg4uD5QOJLGVlqy94RCKgicUoa5SdhDiJKDV00MoM2Cq8e');
    stripe.redirectToCheckout({
        sessionId: sessionId
    });
};


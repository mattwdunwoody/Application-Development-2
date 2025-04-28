package com.virtualpet.VirtualPet.service;

import org.springframework.stereotype.Component;
import java.text.DecimalFormat;

@Component
public class FormatterService {

    private final DecimalFormat decimalFormatter;

    public FormatterService(DecimalFormat decimalFormatter) {
        this.decimalFormatter = decimalFormatter;
    }

    public String FormatAmount(double amount) {
        return decimalFormatter.format(amount);
    }
}

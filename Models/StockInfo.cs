namespace HighChartpratice.Models
{
    public class StockInfo
    {
        public string stock_code { get; set; }
        public string stock_name { get; set; }
        public string industry_code { get; set; }
        public string industry_name { get; set; }
        public string index_type_code { get; set; }
        public string index_type { get; set; }
        public string creator { get; set; }
        public long create_time { get; set; }
        public string modifier { get; set; }
        public long modify_time { get; set; }
        public string revenue { get; set; }
        public string operating_items { get; set; }
        public string issued_shares { get; set; }
        public Daymkdatalist[] dayMkDataList { get; set; }
        public Dayiisbdatalist[] dayIISBDataList { get; set; }
        public Weekmkdatalist[] weekMkDataList { get; set; }
        public Monthmkdatalist[] monthMkDataList { get; set; }
        public Stockcalendardatalist[] stockCalendarDataList { get; set; }
        public Monthrevenuedatalist[] monthRevenueDataList { get; set; }
        public Qfinancialreportdatalist[] qFinancialReportDataList { get; set; }
        public Qstockdividenddatalist[] qStockDividendDataList { get; set; }
        public Directorsupervisordatalist[] directorSupervisorDataList { get; set; }
        public string mdate { get; set; }
        public string open_d { get; set; }
        public string high_d { get; set; }
        public string low_d { get; set; }
        public string close_d { get; set; }
        public string volume { get; set; }
        public string clschg { get; set; }
        public string roi { get; set; }
        public string macd { get; set; }
        public string macddif { get; set; }
        public string kval { get; set; }
        public string dval { get; set; }
        public string dif { get; set; }
        public string bbu20 { get; set; }
        public string bbl20 { get; set; }
        public string rsi5 { get; set; }
        public string rsi10 { get; set; }
        public string udi14 { get; set; }
        public string ddi14 { get; set; }
        public string adx14 { get; set; }
        public string amount { get; set; }
        public string ma5 { get; set; }
        public string ma10 { get; set; }
        public string ma20 { get; set; }
        public string ma60 { get; set; }
        public string ma120 { get; set; }
        public string ma240 { get; set; }
        public string mv5 { get; set; }
        public string mv10 { get; set; }
        public string mv20 { get; set; }
        public string mv60 { get; set; }
        public string mv120 { get; set; }
        public string mv240 { get; set; }
        public string fnamec { get; set; }
        public string tejinm1_c { get; set; }
        public string estb_date { get; set; }
        public string chiadd_c { get; set; }
        public string zamt { get; set; }
        public string list_day1 { get; set; }
        public string main_competitor { get; set; }
    }

    public class Daymkdatalist
    {
        public string mdate { get; set; }
        public string open_d { get; set; }
        public string high_d { get; set; }
        public string low_d { get; set; }
        public string close_d { get; set; }
        public string volume { get; set; }
        public string clschg { get; set; }
        public string roi { get; set; }
        public string macd { get; set; }
        public string macddif { get; set; }
        public string kval { get; set; }
        public string dval { get; set; }
        public string dif { get; set; }
        public string bbu20 { get; set; }
        public string bbl20 { get; set; }
        public string rsi5 { get; set; }
        public string rsi10 { get; set; }
        public string udi14 { get; set; }
        public string ddi14 { get; set; }
        public string adx14 { get; set; }
        public string amount { get; set; }
        public string ma5 { get; set; }
        public string ma10 { get; set; }
        public string ma20 { get; set; }
        public string ma60 { get; set; }
        public string ma120 { get; set; }
        public string ma240 { get; set; }
        public string mv5 { get; set; }
        public string mv10 { get; set; }
        public string mv20 { get; set; }
        public string mv60 { get; set; }
        public string mv120 { get; set; }
        public string mv240 { get; set; }
        public string vol_dt { get; set; }
    }

    public class Dayiisbdatalist
    {
        public string mdate { get; set; }
        public string qfii_ex1 { get; set; }
        public string qfii_examt { get; set; }
        public string qfii_hap { get; set; }
        public string fund_ex { get; set; }
        public string fund_examt { get; set; }
        public string fund_hap { get; set; }
        public string dlr_ex { get; set; }
        public string dlrh_ex { get; set; }
        public string dlrp_ex { get; set; }
        public string dlr_examt { get; set; }
        public string dlr_hap { get; set; }
        public string ttl_ex { get; set; }
        public string gin0 { get; set; }
        public string gin1 { get; set; }
        public string gin4 { get; set; }
        public string gin5 { get; set; }
        public string borr_t1 { get; set; }
        public string sale_b1 { get; set; }
    }

    public class Weekmkdatalist
    {
        public string mdate { get; set; }
        public string open_d { get; set; }
        public string high_d { get; set; }
        public string low_d { get; set; }
        public string close_d { get; set; }
        public string volume { get; set; }
        public string clschg { get; set; }
        public string roi { get; set; }
        public string macd { get; set; }
        public string macddif { get; set; }
        public string kval { get; set; }
        public string dval { get; set; }
        public string dif { get; set; }
        public string bbu20 { get; set; }
        public string bbl20 { get; set; }
        public string rsi5 { get; set; }
        public string rsi10 { get; set; }
        public string udi14 { get; set; }
        public string ddi14 { get; set; }
        public string adx14 { get; set; }
        public string amount { get; set; }
        public string ma5 { get; set; }
        public string ma10 { get; set; }
        public string ma20 { get; set; }
        public string ma60 { get; set; }
        public string ma120 { get; set; }
        public string ma240 { get; set; }
        public string mv5 { get; set; }
        public string mv10 { get; set; }
        public string mv20 { get; set; }
        public string mv60 { get; set; }
        public string mv120 { get; set; }
        public string mv240 { get; set; }
        public string main_ex { get; set; }
        public string main_hap { get; set; }
        public string qfii_ex1 { get; set; }
        public string qfii_hap { get; set; }
        public string fund_ex { get; set; }
        public string fund_hap { get; set; }
        public string dlr_ex { get; set; }
        public string dlrh_ex { get; set; }
    }

    public class Monthmkdatalist
    {
        public string mdate { get; set; }
        public string open_d { get; set; }
        public string high_d { get; set; }
        public string low_d { get; set; }
        public string close_d { get; set; }
        public string volume { get; set; }
        public string clschg { get; set; }
        public string roi { get; set; }
        public string macd { get; set; }
        public string macddif { get; set; }
        public string kval { get; set; }
        public string dval { get; set; }
        public string dif { get; set; }
        public string bbu20 { get; set; }
        public string bbl20 { get; set; }
        public string rsi5 { get; set; }
        public string rsi10 { get; set; }
        public string udi14 { get; set; }
        public string ddi14 { get; set; }
        public string adx14 { get; set; }
        public string amount { get; set; }
        public string ma5 { get; set; }
        public string ma10 { get; set; }
        public string ma20 { get; set; }
        public string ma60 { get; set; }
        public string mv5 { get; set; }
        public string mv10 { get; set; }
        public string mv20 { get; set; }
        public string mv60 { get; set; }
        public string main_ex { get; set; }
        public string main_hap { get; set; }
        public string qfii_ex1 { get; set; }
        public string qfii_hap { get; set; }
        public string fund_ex { get; set; }
        public string fund_hap { get; set; }
        public string dlr_ex { get; set; }
        public string dlrh_ex { get; set; }
        public string last4q_eps { get; set; }
    }

    public class Stockcalendardatalist
    {
        public string mdate { get; set; }
        public string _event { get; set; }
        public string message { get; set; }
        public string link { get; set; }
    }

    public class Monthrevenuedatalist
    {
        public string yearMonth { get; set; }
        public string revenue { get; set; }
        public string revenue_mrate { get; set; }
        public string revenue_yrate { get; set; }
        public string cum_revenue { get; set; }
        public string cum_revenue_mrate { get; set; }
    }

    public class Qfinancialreportdatalist
    {
        public string yearQ { get; set; }
        public string assets { get; set; }
        public string liabilities { get; set; }
        public string 股東權益 { get; set; }
        public string curr_assets { get; set; }
        public string curr_liabilities { get; set; }
        public string con_liabilities_curr { get; set; }
        public string con_liabilities_ncurr { get; set; }
        public string con_liabilities { get; set; }
        public string cumu_eps { get; set; }
        public string eps { get; set; }
        public string eps_rate { get; set; }
        public string value { get; set; }
        public string op_income { get; set; }
        public string op_gross_profit { get; set; }
        public string op_net_profit { get; set; }
        public string net_income { get; set; }
        public string net_income_tax { get; set; }
        public string op_cash { get; set; }
        public string investing_cash { get; set; }
        public string financing_cash { get; set; }
        public string net_cash { get; set; }
        public string equity_rate_tax { get; set; }
        public string assets_rate_tax { get; set; }
        public string pe_rate { get; set; }
        public string gross_profit_rate { get; set; }
        public string op_profit_rate { get; set; }
        public string net_income_rate { get; set; }
        public string net_income_tax_rate { get; set; }
        public string curr_rate { get; set; }
        public string quick_rate { get; set; }
        public string debt_rate { get; set; }
        public string share_capital { get; set; }
        public string common_share_capital { get; set; }
        public string noncurr_liabilities { get; set; }
        public string cash { get; set; }
        public string property_plant { get; set; }
        public string long_liabilities { get; set; }
        public string accounts_receivable { get; set; }
        public string inventory { get; set; }
        public string 採用權益法之投資 { get; set; }
        public string qrevenue_rate { get; set; }
        public string qinventory_turnover_rate { get; set; }
    }

    public class Qstockdividenddatalist
    {
        public string year { get; set; }
        public string q1_aex_date { get; set; }
        public string q1_ex_date { get; set; }
        public string q1_payment_date { get; set; }
        public string q1_cash_dividend { get; set; }
        public string q1_stock_dividend { get; set; }
        public string q1_ex_reference_price { get; set; }
        public string q1_填權息days { get; set; }
        public string q1_yield_rate { get; set; }
        public string q2_aex_date { get; set; }
        public string q2_ex_date { get; set; }
        public string q2_payment_date { get; set; }
        public string q2_cash_dividend { get; set; }
        public string q2_stock_dividend { get; set; }
        public string q2_ex_reference_price { get; set; }
        public string q2_填權息days { get; set; }
        public string q2_yield_rate { get; set; }
        public string q3_aex_date { get; set; }
        public string q3_ex_date { get; set; }
        public string q3_payment_date { get; set; }
        public string q3_cash_dividend { get; set; }
        public string q3_stock_dividend { get; set; }
        public string q3_ex_reference_price { get; set; }
        public string q3_填權息days { get; set; }
        public string q3_yield_rate { get; set; }
        public string q4_aex_date { get; set; }
        public string q4_ex_date { get; set; }
        public string q4_payment_date { get; set; }
        public string q4_cash_dividend { get; set; }
        public string q4_stock_dividend { get; set; }
        public string q4_ex_reference_price { get; set; }
        public string q4_填權息days { get; set; }
        public string q4_yield_rate { get; set; }
    }

    public class Directorsupervisordatalist
    {
        public string mdate { get; set; }
        public string sum1 { get; set; }
        public string ttl_stk { get; set; }
        public string bal { get; set; }
        public string dlr_ho { get; set; }
        public string total_issued { get; set; }
        public string buy_l { get; set; }
        public string gin0 { get; set; }
    }
}

namespace yatzy_project;

public partial class YatzyForm{

    private void deselectAllCategories(){
        for(int index = 0; index < category_selected.Count(); index++){
            category_selected[index] = false;
        }
    }

    // funktio joka luo ääriviivat noppa kategoria painikkeille
    private List<Rectangle> createCategoryBorders(){
        var categoires = getAllCategoryLabels();

        Rectangle border = new Rectangle();
        List<Rectangle> border_list = new List<Rectangle>();

        foreach(Label category in categoires){

            border.X = category.Location.X;
            border.X = category.Location.Y;

            border.Width = category.Width;
            border.Height = category.Height;

            border_list.Add(border);
        }

        return border_list;
    }

    #region Category Click functions

    private void ykkosetLabel_Click(object sender, EventArgs e)
    {   

        if(!category_selected[0] && !category_locked[0]){ // suoritetaan vain silloin kun kategoria ei ole valittuna tai lukittuna
            deselectAllCategories(); // laitetaan kaikki kategoria painikkeet false (myös tämä), koska vain yhtä kategoriaa voi tavoitella kerrallaan

            category_selected[0] = true; // laitetaan merkki että kategoria on valittuna
            this.combinationsPanel.Invalidate(createCategoryBorders()[0]);
        }
        else{
            category_selected[0] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[0]);
        }
        
    }

    private void kakkosetLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[1] && !category_locked[1]){
            deselectAllCategories();

            category_selected[1] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[1]);
        }
        else{
            category_selected[1] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[1]);
        }
    }

    private void kolmosetLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[2] && !category_locked[2]){
            deselectAllCategories();

            category_selected[2] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[2]);
        }
        else{
            category_selected[2] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[2]);
        }
    }

    private void nelosetLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[3] && !category_locked[3]){
            deselectAllCategories();
            
            category_selected[3] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[3]);
        }
        else{
            category_selected[3] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[3]);
        }

    }

    private void viitosetLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[4] && !category_locked[4]){
            deselectAllCategories();
            
            category_selected[4] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[4]);
        }
        else{
            category_selected[4] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[4]);
        }
    }

    private void kuutosetLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[5] && !category_locked[5]){
            deselectAllCategories();
            
            category_selected[5] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[5]);
        }
        else{
            category_selected[5] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[5]);
        }
    }

    private void pariLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[6] && !category_locked[6]){
            deselectAllCategories();
            
            category_selected[6] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[6]);
        }
        else{
            category_selected[6] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[6]);
        }
    }

    private void kaksi_pariaLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[7] && !category_locked[7]){
            deselectAllCategories();
            
            category_selected[7] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[7]);
        }
        else{
            category_selected[7] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[7]);
        }
    }

    private void kolme_samaaLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[8] && !category_locked[8]){
            deselectAllCategories();
            
            category_selected[8] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[8]);
        }
        else{
            category_selected[8] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[8]);
        }
    }

    private void nelja_samaaLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[9] && !category_locked[9]){
            deselectAllCategories();
            
            category_selected[9] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[9]);
        }
        else{
            category_selected[9] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[9]);
        }
    }

    private void pieni_suoraLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[10] && !category_locked[10]){
            deselectAllCategories();

            category_selected[10] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[10]);
        }
        else{
            category_selected[10] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[10]);
        }
    }

    private void iso_suoraLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[11] && !category_locked[11]){
            deselectAllCategories();

            category_selected[11] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[11]);
        }
        else{
            category_selected[11] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[11]);
        }
    }

    private void tayskasiLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[12] && !category_locked[12]){
            deselectAllCategories();

            category_selected[12] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[12]);
        }
        else{
            category_selected[12] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[12]);
        }
    }

    private void sattumaLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[13] && !category_locked[13]){
            deselectAllCategories();

            category_selected[13] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[13]);
        }
        else{
            category_selected[13] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[13]);
        }
    }

    private void yatzyLabel_Click(object sender, EventArgs e)
    {

        if(!category_selected[14] && !category_locked[14]){
            deselectAllCategories();

            category_selected[14] = true;
            this.combinationsPanel.Invalidate(createCategoryBorders()[14]);
        }
        else{
            category_selected[14] = false;
            this.combinationsPanel.Invalidate(createCategoryBorders()[14]);
        }
    }
    #endregion
}